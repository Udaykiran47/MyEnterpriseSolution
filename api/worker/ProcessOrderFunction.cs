using api.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class ProcessOrderFunction
{
    private readonly ILogger<ProcessOrderFunction> _logger;
    private readonly AppDbContext _context;

    public ProcessOrderFunction(ILogger<ProcessOrderFunction> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Function(nameof(ProcessOrderFunction))]
    public async Task Run(
        [QueueTrigger("order-queue", Connection = "AzureWebJobsStorage")] string orderIdString)
    {
        _logger.LogInformation($"Processing queue message for Order ID: {orderIdString}");

        if (int.TryParse(orderIdString, out int orderId))
        {
            var order = await _context.ProductOrders.FindAsync(orderId);
            if (order != null)
            {
                // Step 1: Update status to Processing Details
                order.Status = "Processing";
                order.ProcessingDetails = "Processing Details... Verifying inventory and billing gateway.";
                order.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                // Simulate heavy backend logic (e.g., third-party API processing)
                await Task.Delay(4000);

                // Step 2: Finalize status
                order.Status = "Completed";
                order.ProcessingDetails = "Processing Details... Order successfully fulfilled and verified.";
                order.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
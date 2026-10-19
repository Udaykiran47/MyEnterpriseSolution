using api.Data;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public OrdersController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] ProductOrderDto dto)
    {
        var order = new ProductOrder
        {
            ProductName = dto.ProductName,
            Price = dto.Price,
            Status = "Pending",
            ProcessingDetails = "Order received, queued for background processing."
        };

        _context.ProductOrders.Add(order);
        await _context.SaveChangesAsync();

        // Push ID to Azure Storage Queue for background execution
        var storageConn = _configuration.GetConnectionString("AzureStorageQueue");
        var queueClient = new QueueClient(storageConn, "order-queue");
        await queueClient.CreateIfNotExistsAsync();
        await queueClient.SendMessageAsync(order.Id.ToString());

        return Accepted(new { order.Id, order.Status, Message = "Order successfully queued." });
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _context.ProductOrders.OrderByDescending(o => o.CreatedAt).ToListAsync();
        return Ok(orders);
    }
}
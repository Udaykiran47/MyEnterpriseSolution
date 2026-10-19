-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: myproducts
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `productorders`
--

DROP TABLE IF EXISTS `productorders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productorders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(150) NOT NULL,
  `Price` decimal(18,2) NOT NULL,
  `Status` varchar(50) NOT NULL DEFAULT 'Pending',
  `ProcessingDetails` varchar(500) DEFAULT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productorders`
--

LOCK TABLES `productorders` WRITE;
/*!40000 ALTER TABLE `productorders` DISABLE KEYS */;
INSERT INTO `productorders` VALUES (1,'Wireless Mouse',25.99,'Completed','Dispatched via Express Shipping','2026-10-19 11:45:16','2026-06-01 10:00:00'),(2,'Mechanical Keyboard',89.50,'Pending',NULL,'2026-10-19 11:45:16',NULL),(3,'UltraWide Monitor',349.99,'Processing','Quality check in progress','2026-10-19 11:45:16','2026-06-02 11:30:00'),(4,'USB-C Hub',19.99,'Cancelled','Out of stock','2026-10-19 11:45:16','2026-06-01 14:20:00'),(5,'Ergonomic Office Chair',199.00,'Completed','Delivered to front door','2026-10-19 11:45:16','2026-06-03 09:15:00'),(6,'Laptop Stand',35.50,'Pending',NULL,'2026-10-19 11:45:16',NULL),(7,'Noise-Cancelling Headphones',149.99,'Processing','Packing items','2026-10-19 11:45:16','2026-06-03 16:45:00'),(8,'Portable SSD 1TB',109.99,'Completed','Shipped via standard mail','2026-10-19 11:45:16','2026-06-04 08:30:00');
/*!40000 ALTER TABLE `productorders` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-19 15:47:11

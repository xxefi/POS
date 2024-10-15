namespace POS.Domain.Entities;

    public class InventoryItemEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid InventoryId { get; set; }
        public InventoryEntity? Inventory { get; set; }
    }

namespace HomeFood.Entities.Menu
{
    public class ShopCarEntity
    {
        public int ShopCarId { get; set; }
        public int? CustomerId { get; set; }
        public int? MenuId { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
    }
}
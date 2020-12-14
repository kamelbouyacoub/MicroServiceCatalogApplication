namespace Bascket.API.Entities
{
    public class BasketCartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
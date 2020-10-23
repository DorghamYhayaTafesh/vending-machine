namespace VendingMachine.Products
{
    class TwixProduct : IProducts
    {
        public decimal Price { get; set; } = 3;
        public decimal Row { get; set; }
        public decimal Column { get; set; }
        public ProductsTypes ProductType { get { return ProductsTypes.Twix; } }
        public int TotalItems { get; set; }
        public int AvailableItems { get; set; }
        public decimal weight { set; get; }
        public decimal calories { get; set; }
    }
}

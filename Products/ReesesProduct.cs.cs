namespace VendingMachine.Products
{
    class ReesesProduct : IProducts
    {
        public decimal Price { get; set; } = 3;
        public decimal Row { get; set; }
        public decimal Column { get; set; }
        public ProductsTypes ProductType { get { return ProductsTypes.Reeses; } }
        public int TotalItems { get; set; }
        public int AvailableItems { get; set; }
    }
}

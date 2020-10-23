namespace VendingMachine.Products
{
    class LaysProduct : IProducts
    {
        public decimal Price { get; set; } = 3;
        public decimal Row { get; set; }
        public decimal Column { get; set; }
        public ProductsTypes ProductType { get { return ProductsTypes.Lays; } }
        public int TotalItems { get; set; }
        public int AvailableItems { get; set; }
    }
}

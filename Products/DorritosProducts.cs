namespace VendingMachine.Products
{
    public class DorritosProducts : IProducts
    {
        public decimal Price { get; set; } = 7;
        public decimal Row { get; set; }
        public decimal Column { get; set; }
        public ProductsTypes ProductType { get { return ProductsTypes.Dorritos; } }
        public int TotalItems { get; set; }
        public int AvailableItems { get; set; }
    }
}

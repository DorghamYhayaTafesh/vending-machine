namespace VendingMachine.Products
{
    public class HersheyProduct : IProducts
    {
        public decimal Price { get; set; } = 3;
        public decimal Row { get; set; }
        public decimal Column { get; set; }
        public ProductsTypes ProductType { get { return ProductsTypes.Hershey; } }
        public int TotalItems { get; set; }
        public int AvailableItems { get; set; }
        public decimal Weight { set; get; }
        public decimal Calories { get; set; }
    }
}

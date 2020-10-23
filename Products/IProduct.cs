namespace VendingMachine.Products
{
    public interface IProducts
    {
        decimal Price { get; set; }
        decimal Row { get; set; }
        decimal Column { get; set; }
        ProductsTypes ProductType { get; }
        int TotalItems { get; set; }
        int AvailableItems { get; set; }
    }
}

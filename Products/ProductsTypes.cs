using System.ComponentModel;

namespace VendingMachine.Products
{
    public enum ProductsTypes
    {
        // choclates
        [Description("Reese's")]
        Reeses = 1,
        [Description("Hershey")]
        Hershey = 2,
        [Description("Twix")]
        Twix = 4,
        // chips
        [Description("Lays Chips")]
        Lays = 5,
        [Description("Dorritos Chips")]
        Dorritos = 3
    }
}

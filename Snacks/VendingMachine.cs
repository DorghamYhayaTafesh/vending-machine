using VendingMachine.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendingMachine.Snacks
{
    public interface IVendingMachine
    {
        VendingMachineTypes Type { get; }
        int Rows { get; set; }
        int Columns { get; set; }
        List<IProducts> Products { set; get; }
        List<IProducts> GetAvailableProducts();
        Task TakeProductOut(ProductsTypes productType);

    }
}

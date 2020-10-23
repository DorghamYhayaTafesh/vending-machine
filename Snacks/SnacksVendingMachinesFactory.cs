using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine.Snacks
{
    public class SnacksVendingMachinesFactory : VendingMachinesFactory
    {
        public SnacksVendingMachinesFactory()
        {
            SnackMachine.Instance.Columns = 5;
            SnackMachine.Instance.Rows = 5;
        }

        public SnacksVendingMachinesFactory(List<IProducts> products)
        {
            SnackMachine.Instance.Columns = 5;
            SnackMachine.Instance.Rows = 5;
            SnackMachine.Instance.Products = products;
        }

        public override IVendingMachine GetVendingMachine()
        {
            return SnackMachine.Instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Products;

namespace VendingMachine.Snacks
{
    // singelton and lazy loading used. 
    // sealed class is used to prevent any other class from inheriting this logic 
    public sealed class SnackMachine: IVendingMachine
    {
        private static readonly Lazy<SnackMachine>
            lazy =
            new Lazy<SnackMachine>
                (() => new SnackMachine());

        public  static SnackMachine Instance { get { return lazy.Value; } }

        private SnackMachine() {}
        // can not be change from outside the class. only get.
        public VendingMachineTypes Type
        {
            get { return VendingMachineTypes.SnackVendingMachine; }
        }

        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<IProducts> Products { get; set; }
        // returns the products that have availableItems > 0
        public List<IProducts> GetAvailableProducts()
        {
            List<IProducts> availableProducts = new List<IProducts>();
            foreach(var product in Products)
            {
                if(product.AvailableItems > 0)
                {
                    availableProducts.Add(product);
                }
            }
            return availableProducts;
        }
        // subtract one from the corresponding item type available items attribute.
        // this function should be called when the payment succeeed and the machine pushed the item to the user. 
        public async Task TakeProductOut(ProductsTypes productType)
        {
            this.Products.FirstOrDefault(prod => prod.ProductType.Equals(productType)).AvailableItems--;
        }
    }
}

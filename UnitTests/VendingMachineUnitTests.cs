using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Products;
using VendingMachine.Snacks;
using Xunit;

namespace VendingMachine.UnitTests
{
    public class VendingMachineUnitTests
    {
        private readonly IVendingMachine _machine;
        private readonly Mock<IProducts> _product;
        private readonly Mock<Startup> _startup;

        public VendingMachineUnitTests()
        {
            // do mocking for needed classes and interfaces
            _machine = SnackMachine.Instance;
            _product = new Mock<IProducts>();
            _machine.Products = this.getTestProducts();
            _startup = new Mock<Startup>();

        }
        // test the getAvailableItem function should return the available products 
        [Fact]
        public async Task GetAvailableItem_ShouldReturnCorrectCount()
        {
            Assert.Equal((getTestProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Reeses))),
                _machine.GetAvailableProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Reeses)));

            Assert.Equal((getTestProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Dorritos))),
                _machine.GetAvailableProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Dorritos)));
        }

        // test the getAvailableItem function should return the available products 
        [Fact]
        public async Task TakeProductOut_ShouldReturnCorrectCountAfterDeletingAnItem()
        {
            await _machine.TakeProductOut(ProductsTypes.Dorritos);
            Assert.Empty(_machine.GetAvailableProducts().Where(prod => prod.ProductType.Equals(ProductsTypes.Dorritos)));
            await _machine.TakeProductOut(ProductsTypes.Reeses);
            Assert.Equal((getTestProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Reeses)) - 1),
                _machine.GetAvailableProducts().Count(prod => prod.ProductType.Equals(ProductsTypes.Reeses)));
        }

        // throw exception when there is no payment method selected
        public async Task SelectPaymentMethod_ShouldThrowExceptionWhenNoPaymentMethodAdded()
        {
            Startup.SelectPaymentMethod(It.IsAny<ProductsTypes>());
            Assert.Throws<InvalidOperationException>(() => Startup.SelectPaymentMethod(It.IsAny<ProductsTypes>()));
        }

        private List<IProducts> getTestProducts()
        {
            return new List<IProducts>
            {
                new HersheyProduct { TotalItems = 5, AvailableItems = 2, Price = 3 },
                new DorritosProducts { Price = 5, AvailableItems = 1, TotalItems = 2 }
            };
        }
    }
}

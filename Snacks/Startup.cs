using Autofac;
using EnumsNET;
using System;
using System.Collections.Generic;
using VendingMachine.InternalBusMessages;
using VendingMachine.Products;

namespace VendingMachine.Snacks
{
    public class Startup
    {
        private static  SnacksVendingMachinesFactory _factory;
        public Startup(SnacksVendingMachinesFactory factory)
        {
            _factory = factory;
        }
        static void Main(string[] args)
        {
            // init dependency injection
            var builder = new ContainerBuilder();
            builder.RegisterType<DorritosProducts>().As<IProducts>();
            builder.RegisterType<SnackMachine>().As<IVendingMachine>();
            builder.RegisterType<SnacksVendingMachinesFactory>().AsSelf();
            builder.Build();

            StartVendingProcess();
        }

        public static void StartVendingProcess()
        {
            Console.WriteLine($"Welcom to Frieghtos Vending Machines: {Environment.NewLine} Which vending machine you want to use ?");
            Console.WriteLine($"For Coffe Machine please press: {VendingMachineTypes.CoffeVendingMachine}");
            Console.WriteLine($"For Snacks Machine please press: {VendingMachineTypes.SnackVendingMachine}");
            // by default get the singelton instance of the snacks machine
            IVendingMachine machine = _factory.GetVendingMachine();
            int vendingMachineType;

            // check of the users want to use another non-implemented machine and show exception
            if (int.TryParse(Console.ReadLine(), out vendingMachineType))
            {
                if (!((VendingMachineTypes)vendingMachineType).Equals(VendingMachineTypes.SnackVendingMachine))
                {
                    throw new NotImplementedException("Only the Snacks Machine is implemented so far.");
                }
            }
            else
            {
                throw new InvalidOperationException("please enter a valid number for vending machine");
            }

            // initialize the snack vending machine with demo data.
            InitializeVendingMachine(machine);
            Console.WriteLine("Welcome to Snacks Vending Machine, please select the Snack you wish to purchase from the following available Snaks:");
            ProductsTypes? selectedProduct;
            try
            {
                // asks the user to select a product among only the available items.
                selectedProduct = SelectProduct(machine);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidOperationException("Please Enter a valid number of a product.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("an issue happened while selecting your order, please try again.");
            }

            try
            {
                // asks the user to select a payment method among only the available slots.
                SelectPaymentMethod(selectedProduct.Value);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidOperationException("Please Enter a valid number of a product.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("an issue happened while selecting your order, please try again.");
            }
        }

        public static void SelectPaymentMethod(ProductsTypes selectedProduct)
        {
            int selecedChoice;

            Console.WriteLine("Please select how you would like to pay:");
            // enumeration over the existing slot types from enum
            foreach (var item in Enum.GetValues(typeof(SlotTypes)))
            {
                Console.WriteLine($"Press {item} for {((SlotTypes)item).AsString(EnumFormat.Description)}");
            }
            if (int.TryParse(Console.ReadLine(), out selecedChoice))
            {
                switch ((SlotTypes)selecedChoice)
                {
                    // publish a message according to the user choice
                    case SlotTypes.CardSlot:
                        RabbitMQPublisher.PublishMessage(new OpenCardSlotMessage() { CreatedDate = DateTimeOffset.UtcNow, ProductType = (int)selectedProduct }); break;
                    case SlotTypes.CoinSlot:
                        RabbitMQPublisher.PublishMessage(new OpenCoinSlotMessage() { CreatedDate = DateTimeOffset.UtcNow, ProductType = (int)selectedProduct }); break;
                    case SlotTypes.NotesSlot:
                        RabbitMQPublisher.PublishMessage(new OpenNotesSlotMessage() { CreatedDate = DateTimeOffset.UtcNow, ProductType = (int)selectedProduct }); break;

                }
            } else
            {
                throw new InvalidOperationException("please enter a valid number for the slot");
            }
        }

        public static ProductsTypes SelectProduct(IVendingMachine machine)
        {
            var products = machine.GetAvailableProducts();
            // enumeration over the existing/available products
            foreach (IProducts item in products)
            {
                Console.WriteLine($"For {(item.ProductType).AsString(EnumFormat.Description)} Please Press: ${item.Row} ${item.Column}");
            }
            int selecedProduct;
            if(int.TryParse(Console.ReadLine(), out selecedProduct))
            {
                return ((ProductsTypes)selecedProduct);
            } else
            {
                throw new InvalidOperationException("please enter a valid number for product");
            }
        }

        public static void InitializeVendingMachine(IVendingMachine machine)
        {
            List<IProducts> products = new List<IProducts>();
            products.Add(new HersheyProduct { AvailableItems = 5, Calories = 300, Column = 1, Row = 1, TotalItems = 5, Weight = 5 });
            products.Add(new DorritosProducts { AvailableItems = 5, Column = 1, Row = 1, TotalItems = 5 });
            machine.Products = products;
        }
    }

}

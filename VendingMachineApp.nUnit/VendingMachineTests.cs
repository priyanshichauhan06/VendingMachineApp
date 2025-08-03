using VendingMachineApp.Models;
using VendingMachineApp.Common;
using VendingMachineApp.Services;

namespace VendingMachineApp.Tests
{
    public class VendingMachineTests
    {
        private VendingMachine vendingMachine;
        private Display display;

        // Initializes a new instance of the vending machine and resets the product list before each test
        [SetUp]
        public void Setup()
        {
            display = new Display();
            vendingMachine = new VendingMachine(display);

            ProductList.Products.Clear();
            ProductList.Products[ProductConstants.Cola] = new Product (ProductConstants.Cola, ProductConstants.ColaPrice);
        }

        [Test]
        [Description("Inserts a valid coin i.e. Quarters and verifies that the current amount is updated correctly with no error message.")]
        public void AcceptCoin_ValidCoin_UpdatesAmount()
        {
            vendingMachine.AcceptCoin(CoinType.Quarters);

            Assert.That(display.CurrentPaidAmount, Is.EqualTo(CoinConstants.QuarterValue));
            Assert.That(display.GetMessage(), Is.Empty);
        }

        [Test]
        [Description("Inserts an invalid coin i.e. Pennies and checks that an error message is displayed and the coin is added to the coin return.")]
        public void AcceptCoin_InvalidCoin_Pennies_ShouldDisplayError()
        {
            vendingMachine.AcceptCoin(CoinType.Pennies);

            Assert.That(display.GetMessage(), Is.EqualTo(DisplayMessages.PennyMessage));

            var coinReturn = vendingMachine.GetCoinReturn();
            Assert.That(coinReturn, Does.Contain(CoinType.Pennies));
        }

        [Test]
        [Description("Inserts the exact required amount for a product and verifies that the product is dispensed, amount is reset, and success message is shown.")]
        public void SelectProduct_WithExactAmount_Successfully_DispensesProduct()
        {
            var selectedProduct = ProductConstants.Cola;

            vendingMachine.AcceptCoin(CoinType.Quarters);
            vendingMachine.AcceptCoin(CoinType.Quarters);
            vendingMachine.AcceptCoin(CoinType.Quarters);
            vendingMachine.AcceptCoin(CoinType.Quarters);
            vendingMachine.SelectProduct(selectedProduct);

            var expectedMessage = string.Format(DisplayMessages.SuccessMessage, selectedProduct);
            Assert.That(display.GetMessage(), Does.Contain(expectedMessage));

            Assert.That(display.CurrentPaidAmount, Is.EqualTo(ProductConstants.DefaultPrice));
            Assert.That(display.RemainingAmount, Is.EqualTo(ProductConstants.DefaultPrice));
        }

        [Test]
        [Description("Inserts an insufficient amount and selects a product. Verifies that the product and price are shown, and remaining amount is calculated correctly.")]
        public void SelectProduct_InsufficientAmount_ShowsRemaining()
        {
            var selectedProduct = ProductConstants.Cola;

            vendingMachine.AcceptCoin(CoinType.Dimes);
            vendingMachine.SelectProduct(selectedProduct);

            Assert.That(display.CurrentPaidAmount, Is.EqualTo(0.10m));
            Assert.That(display.RemainingAmount, Is.EqualTo(0.90m));
            Assert.That(display.ProductName, Is.EqualTo(selectedProduct));
            Assert.That(display.ProductPrice, Is.EqualTo(1.00m));
        }

        [Test]
        [Description("Attempts to select a non-existent product and verifies that the invalid input message is shown.")]
        public void SelectProduct_InvalidProduct_ShowsError()
        {
            vendingMachine.SelectProduct("Chocolates");

            Assert.That(display.GetMessage(), Is.EqualTo(DisplayMessages.InvalidInput));
        }
    }
}

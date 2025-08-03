using NUnit.Framework;
using VendingMachineApp.Common;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Tests
{
    public class DisplayTests
    {
        private Display display;

        // Initialize the Display object before each test
        [SetUp]
        public void Setup()
        {
            display = new Display();
        }

        [Test]
        [Description("Validates that DisplayMessage sets the internal message correctly, which is later returned using GetMessage().")]
        public void DisplayMessage_ShouldStoreMessage()
        {
            display.DisplayMessage(DisplayMessages.WelcomeMessage);
            Assert.That(display.GetMessage(), Is.EqualTo(DisplayMessages.WelcomeMessage));
        }

        [Test]
        [Description("Ensures UpdateAmount method correctly updates the current paid amount and remaining amount on the display.")]
        public void UpdateAmount_ShouldSetCurrentAndRemainingAmounts()
        {
            display.UpdateAmount(0.25m, 0.75m);
            Assert.That(display.CurrentPaidAmount, Is.EqualTo(0.25m));
            Assert.That(display.RemainingAmount, Is.EqualTo(0.75m));
        }

        [Test]
        [Description("Checks that DisplayProductName correctly assigns the product name to be displayed.")]
        public void DisplayProductName_ShouldSetProductName()
        {
            display.DisplayProductName(ProductConstants.Cola);
            Assert.That(display.ProductName, Is.EqualTo(ProductConstants.Cola));
        }

        [Test]
        [Description("Verifies that DisplayProductPrice correctly updates the product's price on the display.")]
        public void DisplayProductPrice_ShouldSetProductPrice()
        {
            display.DisplayProductPrice(ProductConstants.ChipsPrice);
            Assert.That(display.ProductPrice, Is.EqualTo(ProductConstants.ChipsPrice));
        }

        [Test]
        [Description("Tests that ResetProductSelection clears all product-related display fields including product name, product price, and remaining amount.")]
        public void ResetProductSelection_ShouldClearProductInfo()
        {
            display.DisplayProductName(ProductConstants.Cola);
            display.DisplayProductPrice(1.00m);
            display.UpdateAmount(0.25m, 0.75m);

            display.ResetProductSelection();

            Assert.Multiple(() =>
            {
                Assert.That(display.ProductName, Is.EqualTo(string.Empty), "Product name should be cleared.");
                Assert.That(display.ProductPrice, Is.EqualTo(ProductConstants.DefaultPrice), "Product price should be reset.");
                Assert.That(display.RemainingAmount, Is.EqualTo(ProductConstants.DefaultPrice), "Remaining amount should be reset.");
            });
        }
    }
}

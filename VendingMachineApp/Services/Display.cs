
using VendingMachineApp.Common;
using VendingMachineApp.Interfaces;

namespace VendingMachineApp.Services
{
    /// <summary>
    /// Handles display-related updates for the vending machine, such as showing messages, product info, and payment status.
    /// </summary>
    public class Display : IDisplay
    {
        public string ShowMessage { get; set; } = string.Empty;
        public string ProductName { get; private set; } = string.Empty;
        public decimal ProductPrice { get; private set; } = ProductConstants.DefaultPrice;
        public decimal CurrentPaidAmount { get; private set; } = ProductConstants.DefaultPrice;
        public decimal RemainingAmount { get; private set; } = ProductConstants.DefaultPrice;

        // Updates the current and remaining amount after coin insertion
        public void UpdateAmount(decimal current, decimal remaining = ProductConstants.DefaultPrice)
        {
            CurrentPaidAmount = current;
            RemainingAmount = remaining;
        }

        // Displays message on the machine
        public void DisplayMessage(string message)
        {
            ShowMessage = message;
        }

        // Returns the current message shown on the display
        public string GetMessage()
        {
            return ShowMessage;
        }

        // Sets the product name to display
        public void DisplayProductName(string productName)
        {
            ProductName = productName;
        }

        // Sets the product price to display
        public void DisplayProductPrice(decimal productPrice)
        {
            ProductPrice = productPrice;
        }

        // Resets the product selection and clears related display fields
        public void ResetProductSelection()
        {
            ProductName = string.Empty;
            ProductPrice = ProductConstants.DefaultPrice;
            RemainingAmount = ProductConstants.DefaultPrice;
        }
    }
}

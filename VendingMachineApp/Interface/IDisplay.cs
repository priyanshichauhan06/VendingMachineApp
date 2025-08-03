using VendingMachineApp.Common;

namespace VendingMachineApp.Interfaces
{
    /// <summary>
    /// Defines the display messages for a vending machine.
    /// </summary>
    public interface IDisplay
    {
        void DisplayMessage(string message);
        void DisplayProductName(string name);
        void DisplayProductPrice(decimal price);
        void UpdateAmount(decimal current, decimal remaining = ProductConstants.DefaultPrice);
        void ResetProductSelection();
        string GetMessage();
    }
}

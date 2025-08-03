namespace VendingMachineApp.Common
{
    /// <summary>
    /// Contains all the messages displayed by the vending machine.
    /// </summary>
    public static class DisplayMessages
    {
        public const string WelcomeMessage = "WELCOME TO THE VENDING MACHINE!";
        public const string AcceptedCoins = "Accepted Coins: Nickels ($0.05), Dimes ($0.10), Quarters ($0.25)";
        public const string AvailableProducts = "Available Products:";
        public const string ExitInstruction = "Type 'exit' to quit.\n";
        public const string InsertPrompt = "Insert coin or select product: ";
        public const string InvalidInput = "Oops! Invalid input. Please try again. :(";
        public const string ProductNotFound = "Product doesn't exist. Please try again :(";
        public const string ThankYouMessage = "\nThank you for using the Vending Machine! :)";
        public const string InvalidCoinMessage = "Invalid coin returned.";
        public const string PennyMessage = "Sorry, Pennies are invalid coin. Returning $0.01";
        public const string SuccessMessage = "THANK YOU! Your {0} is successfully dispensed. :)";
        public const string Separator = "--------------------------------------------";
        public const string CurrentlyPaidAmountLabel = "\nCurrently Paid Amount: ${0}";
        public const string RemainingAmountLabel = "Remaining Amount: ${0}";
        public const string ReturningChangeMessage = "Returning amount = ${0}";
        public const string ProductDetails = "Product: {0} | Price: ${1}";
    }
}

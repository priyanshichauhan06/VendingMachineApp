namespace VendingMachineApp.Common
{
    /// <summary>
    /// Defines the available products and their corresponding prices.
    /// </summary>
    public static class ProductConstants
    {
        // Product names
        public const string Cola = "Cola";
        public const string Chips = "Chips";
        public const string Candy = "Candy";

        // Prices of the products
        public const decimal ColaPrice = 1.00m;
        public const decimal ChipsPrice = 0.50m;
        public const decimal CandyPrice = 0.65m;

        // Default prices
        public const decimal DefaultPrice = 0.00m;
    }
}

using VendingMachineApp.Common;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

class Program
{
    static void Main()
    {
        var display = new Display();
        var vendingMachine = new VendingMachine(display);

        // Dictionary to map button numbers to product names
        var productButton = new Dictionary<string, string>();
        int buttonNumber = 1;

        // Display welcome and available products
        Console.WriteLine(DisplayMessages.WelcomeMessage);
        Console.WriteLine(DisplayMessages.Separator);
        Console.WriteLine(DisplayMessages.AvailableProducts);

        // Display each product with their respective buttons
        foreach (var product in ProductList.Products)
        {
            string button = buttonNumber.ToString();
            productButton[button] = product.Key;
            Console.WriteLine($"[{button}] {product.Value.ProductName} - ${product.Value.ProductPrice}");
            buttonNumber++;
        }

        // Display accepted coins and exit instructions
        Console.WriteLine(DisplayMessages.AcceptedCoins);
        Console.WriteLine(DisplayMessages.ExitInstruction);

        while (true)
        {
            Console.WriteLine(string.Format(DisplayMessages.CurrentlyPaidAmountLabel, display.CurrentPaidAmount));
            Console.WriteLine(string.Format(DisplayMessages.RemainingAmountLabel, display.RemainingAmount));
            Console.WriteLine(DisplayMessages.Separator);

            // Show message if available
            var message = display.GetMessage();
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
                Console.WriteLine(DisplayMessages.Separator + "\n");
                display.ResetProductSelection();
                display.DisplayMessage(string.Empty);
            }

            // Show selected product details if any
            if (!string.IsNullOrEmpty(display.ProductName))
            {
                Console.WriteLine(string.Format(DisplayMessages.ProductDetails, display.ProductName, display.ProductPrice));
            }

            Console.Write(DisplayMessages.InsertPrompt);
            var input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input))
                continue;

            if (input == "exit")
                break;

            // Handle product selection by their respective buttons
            if (productButton.TryGetValue(input, out var productKey))
            {
                vendingMachine.SelectProduct(productKey);
            }
            // Handle invalid product number
            else if (int.TryParse(input, out int productNumber))
            {
                if (!productButton.ContainsKey(productNumber.ToString()))
                {
                    Console.WriteLine(DisplayMessages.ProductNotFound);
                }
            }
            // Handle coin insertion
            else if (Enum.TryParse(typeof(CoinType), Capitalize(input), out var coin))
            {
                vendingMachine.AcceptCoin((CoinType)coin);
            }
            // Handle any invalid input
            else
            {
                Console.WriteLine(DisplayMessages.InvalidInput);
            }
        }

        Console.WriteLine(DisplayMessages.ThankYouMessage);
    }

    // Capitalizes the first letter of a string (used for matching enum values)
    static string Capitalize(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

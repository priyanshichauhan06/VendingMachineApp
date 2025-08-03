using VendingMachineApp.Common;
using VendingMachineApp.Interfaces;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    /// <summary>
    /// Handles vending machine operations including coin acceptance, product selection, and display updates.
    /// </summary>
    public class VendingMachine
    {
        private decimal currentAmount = ProductConstants.DefaultPrice;
        private readonly List<CoinType> coinReturn = new();
        private readonly IDisplay display;
        private Product? pendingProduct = null;

        // Coin values mapped to their types
        private readonly Dictionary<CoinType, decimal> coinValues = new()
        {
            { CoinType.Nickels, CoinConstants.NickelValue },
            { CoinType.Dimes, CoinConstants.DimeValue },
            { CoinType.Quarters, CoinConstants.QuarterValue },
            { CoinType.Pennies, CoinConstants.PennyValue } // Penny is invalid
        };

        public VendingMachine(IDisplay display)
        {
            this.display = display;
            display.UpdateAmount(currentAmount);
        }

        /// <summary>
        /// Accepts a coin, updates the current amount, and processes product dispensing if applicable.
        /// </summary>
        /// <param name="coin">The type of coin inserted into the machine.</param>
        public void AcceptCoin(CoinType coin)
        {
            if (coin == CoinType.Pennies)
            {
                coinReturn.Add(coin);
                display.DisplayMessage(DisplayMessages.PennyMessage);
                return;
            }

            if (coinValues.TryGetValue(coin, out var value) && coin != CoinType.Pennies)
            {
                display.DisplayMessage(string.Empty);
                currentAmount += value;

                if (pendingProduct != null && currentAmount >= pendingProduct.ProductPrice)
                {
                    var returnAmount = currentAmount - pendingProduct.ProductPrice;
                    currentAmount -= pendingProduct.ProductPrice;

                    var message = string.Format(DisplayMessages.SuccessMessage, pendingProduct.ProductName);
                    if (returnAmount > 0)
                    {
                        message += "\n" + string.Format(DisplayMessages.ReturningChangeMessage, returnAmount);
                    }
                    display.DisplayMessage(message);

                    pendingProduct = null;
                    display.UpdateAmount(currentAmount = ProductConstants.DefaultPrice);
                }
                else if (pendingProduct != null)
                {
                    var remaining = pendingProduct.ProductPrice - currentAmount;
                    display.UpdateAmount(currentAmount, remaining);
                }
                else
                {
                    display.UpdateAmount(currentAmount);
                }
            }
            else
            {
                coinReturn.Add(coin);
                display.DisplayMessage(DisplayMessages.InvalidCoinMessage);
            }
        }

        /// <summary>
        /// Selects a product and checks whether sufficient funds are available to purchase it.
        /// </summary>
        /// <param name="productName">The name of the product to purchase.</param>
        public void SelectProduct(string productName)
        {
            if (!ProductList.Products.TryGetValue(productName, out var product))
            {
                display.DisplayMessage(DisplayMessages.InvalidInput);
                return;
            }

            if (currentAmount >= product.ProductPrice)
            {
                var returnAmount = currentAmount - product.ProductPrice;
                currentAmount -= product.ProductPrice;

                var message = string.Format(DisplayMessages.SuccessMessage, productName);
                if (returnAmount > 0)
                {
                    message += "\n" + string.Format(DisplayMessages.ReturningChangeMessage, returnAmount);
                }
                display.DisplayMessage(message);

                currentAmount = ProductConstants.DefaultPrice;
                display.UpdateAmount(currentAmount);
                pendingProduct = null;
            }
            else
            {
                display.DisplayProductName($"{product.ProductName}");
                display.DisplayProductPrice(product.ProductPrice);

                var remaining = product.ProductPrice - currentAmount;
                display.UpdateAmount(currentAmount, remaining);
                pendingProduct = product;
            }
        }

        // Returns the list of coins that were rejected or returned.
        public List<CoinType> GetCoinReturn() => new(coinReturn);
    }
}

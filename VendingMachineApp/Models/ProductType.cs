using VendingMachineApp.Common;
using VendingMachineApp.Models;

/// <summary>
/// Contains the list of available products in the vending machine.
/// </summary>
public static class ProductList
{
    /// <summary>
    /// Dictionary of product names and their corresponding Product objects.
    /// </summary>
    public static readonly Dictionary<string, Product> Products = new()
    {
        { ProductConstants.Cola, new Product(ProductConstants.Cola, ProductConstants.ColaPrice) },
        { ProductConstants.Chips, new Product(ProductConstants.Chips, ProductConstants.ChipsPrice) },
        { ProductConstants.Candy, new Product(ProductConstants.Candy, ProductConstants.CandyPrice) }
    };
}

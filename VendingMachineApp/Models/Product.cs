namespace VendingMachineApp.Models
{
    /// <summary>
    /// Represents the products with name and price.
    /// </summary>
    public class Product
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Constructor to initialize product with name and price.
        /// </summary>
        public Product(string name, decimal price)
        {
            ProductName = name;
            ProductPrice = price;
        }
    }
}

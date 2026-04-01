namespace Covert.Horse.Domain.Order;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public List<string> Items { get; set; } = new List<string>();

    public decimal TotalAmount { get; set; }

    public Order(string customerName, List<string> items, decimal totalAmount)
    {
        if (string.IsNullOrEmpty(customerName))
        {
            throw new ArgumentNullException(nameof(customerName));
        }

        if (items == null || items.Count == 0)
        {
            throw new ArgumentException("Order must contain at least one item.");
        }

        if (totalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be greater than zero.");
        }

        CustomerName = customerName;
        Items = items;
        TotalAmount = totalAmount;
    }
}
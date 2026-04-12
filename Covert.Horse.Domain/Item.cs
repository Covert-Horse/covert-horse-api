namespace Covert.Horse.Domain;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public List<Rating> Ratings { get; set; } = new();

    public Item(string name, string description, string brand, decimal price)
    {
        Name = name;
        Description = description;
        Brand = brand;
        Price = price;
    }

    public void AddRating(Rating rating)
    {
        Ratings.Add(rating);
    }
}
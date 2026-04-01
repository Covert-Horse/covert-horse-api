namespace Covert.Horse.Domain.Catalog;

public class Rating
{
    public int Id { get; set; }
    public int Stars { get; set; }
    public string Review { get; set; }

    public Rating(int stars, string review)
    {
        if (stars < 1 || stars > 5)
        {
            throw new ArgumentException("Stars must be between 1 and 5.");
        }

        if (string.IsNullOrEmpty(review))
        {
            throw new ArgumentNullException(nameof(review));
        }

        Stars = stars;
        Review = review;
    }
}
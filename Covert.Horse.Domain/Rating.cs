namespace Covert.Horse.Domain;

public class Rating
{
    public int Stars { get; set; }
    public string UserName { get; set; }
    public string Review { get; set; }

    public Rating(int stars, string userName, string review)
    {
        if (stars < 1 || stars > 5)
        {
            throw new ArgumentException("Stars must be between 1 and 5");
        }

        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentException("UserName cannot be null or empty");
        }

        Stars = stars;
        UserName = userName;
        Review = review;
    }
}
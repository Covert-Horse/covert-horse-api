using Microsoft.VisualStudio.TestTools.UnitTesting;
using Covert.Horse.Domain.Catalog;

namespace Covert.Horse.Domain.Tests;

[TestClass]
public class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        // Arrange
        var rating = new Rating(5, "Great fit!");

        // Assert
        Assert.AreEqual(5, rating.Stars);
        Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    public void Cannot_Create_Rating_With_Invalid_Stars()
    {
        // Arrange
        bool exceptionThrown = false;

        try
        {
            var rating = new Rating(0, "Bad rating");
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert
        Assert.IsTrue(exceptionThrown);
    }
}
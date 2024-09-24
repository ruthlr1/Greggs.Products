using Greggs.Products.Application.Application.Currency;
using Xunit;
using static Greggs.Products.Application.Application.Currency.CurrencyFactory;

namespace Greggs.Products.UnitTests;

public class CurrencyTests
{
    [Fact]
    public void Given_CurrencyInEuros_When_PoundIs100_Then_CalculatedEuroWillBe_111()
    {
        // Arrange
        decimal priceInPounds = 100;
        CurrencyFactory factory = new CurrencyFactory(CurrencyTypeIndex.Euro);

        // act
        var euros = factory.ConvertPoundToCurrency(priceInPounds);

        // Assert
        Assert.Equal(111, euros);
    }

    [Fact]
    public void Given_CurrencyInEuros_When_PoundIsSmallNumber_Then_CalculatedEuro_willBeInTwoDecimalPlaces()
    {
        // Arrange
        decimal priceInPounds = 0.55M;
        CurrencyFactory factory = new CurrencyFactory(CurrencyTypeIndex.Euro);

        // act
        var euros = factory.ConvertPoundToCurrency(priceInPounds);

        // Assert
        Assert.Equal(0.61M, euros);
    }

    [Fact]
    public void Given_CurrencyNotDefined_Then_CalculatedValueWillRemainTheSameValue()
    {
        // Arrange
        decimal priceInPounds = 0.41M;
        CurrencyFactory factory = new CurrencyFactory();

        // act
        var value = factory.ConvertPoundToCurrency(priceInPounds);

        // Assert
        Assert.Equal(priceInPounds, value);
    }
}
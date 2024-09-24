using System;

namespace Greggs.Products.Application.Application.Currency;

public class CurrencyFactory
{
    private const decimal PoundToEuroConvertionRate = 1.11M;
    public enum CurrencyTypeIndex
    {
        None,
        Euro,
    }

    public CurrencyFactory()
    {
    }

    public CurrencyFactory(CurrencyTypeIndex currencyType)
    {
        CurrencyType = currencyType;
    }

    public CurrencyTypeIndex CurrencyType { get; set; } = CurrencyTypeIndex.None;

    public decimal ConvertPoundToCurrency(decimal value)
    {
        decimal result = 0;
        switch (CurrencyType)
        {
            case CurrencyTypeIndex.Euro:
                result =  value * PoundToEuroConvertionRate;
                break;
            default:
                result =  value;
                break;
        }

        return Math.Round(result, 2);
    }
}

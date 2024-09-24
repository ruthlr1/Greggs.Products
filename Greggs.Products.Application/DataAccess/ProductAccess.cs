using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Application.Application.Currency;
using Greggs.Products.Application.Models;

namespace Greggs.Products.Application.DataAccess;

/// <summary>
/// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
/// </summary>
public class ProductAccess : IDataAccess<Product>
{
    private static readonly IEnumerable<Product> ProductDatabase = new List<Product>()
    {
        new() { Name = "Sausage Roll", PriceInPounds = 1m },
        new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.1m },
        new() { Name = "Steak Bake", PriceInPounds = 1.2m },
        new() { Name = "Yum Yum", PriceInPounds = 0.7m },
        new() { Name = "Pink Jammie", PriceInPounds = 0.5m },
        new() { Name = "Mexican Baguette", PriceInPounds = 2.1m },
        new() { Name = "Bacon Sandwich", PriceInPounds = 1.95m },
        new() { Name = "Coca Cola", PriceInPounds = 1.2m }
    };

    private IQueryable<Product> GetProductQuery(int? pageStart, int? pageSize)
    {
        var queryable = ProductDatabase.AsQueryable();

        if (pageStart.HasValue)
            queryable = queryable.Skip(pageStart.Value);

        if (pageSize.HasValue)
            queryable = queryable.Take(pageSize.Value);

        return queryable;
    }

    public IEnumerable<Product> List(int? pageStart, int? pageSize)
    {
        var queryable = GetProductQuery(pageStart, pageSize);

        return queryable.ToList();
    }

    public IEnumerable<Product> ListByCurrency(CurrencyFactory.CurrencyTypeIndex currency, int? pageStart, int? pageSize)
    {
        var factory = new CurrencyFactory(currency);

        var queryable = GetProductQuery(pageStart, pageSize);

        return queryable.Select(x => new Product(x) { PriceInCurrency = factory.ConvertPoundToCurrency(x.PriceInPounds) } ).ToList();
    }
}
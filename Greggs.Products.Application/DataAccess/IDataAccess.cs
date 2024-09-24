using Greggs.Products.Application.Application.Currency;
using System.Collections.Generic;

namespace Greggs.Products.Application.DataAccess;

public interface IDataAccess<out T>
{
    IEnumerable<T> List(int? pageStart, int? pageSize);
    IEnumerable<T> ListByCurrency(CurrencyFactory.CurrencyTypeIndex currency, int? pageStart, int? pageSize);
}
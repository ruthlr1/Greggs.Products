using System.Collections.Generic;
using Greggs.Products.Application.Application.Currency;
using Greggs.Products.Application.DataAccess;
using Greggs.Products.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IDataAccess<Product> _dataAccess;

    public ProductController(ILogger<ProductController> logger, IDataAccess<Product> dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    [HttpGet]
    public IEnumerable<Product> Get(int pageStart = 0, int pageSize = 5)
    {
        return _dataAccess.List(pageStart, pageSize);
    }

    [HttpGet("GetByCurrency")]
    public IEnumerable<Product> GetByCurrency(CurrencyFactory.CurrencyTypeIndex currency, int pageStart = 0, int pageSize = 5)
    {
        return _dataAccess.ListByCurrency(currency, pageStart, pageSize);
    }
}
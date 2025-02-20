using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeBean.data;
using System.Collections.Generic;
using System.Linq;

namespace TheCoffeeBean.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        Products = _context.Products.Take(3).ToList();

    }
}

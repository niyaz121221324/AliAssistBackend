using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AliAssistApp.Models;

namespace AliAssistApp.Services;

public class AliExpressProductService : IAliExpressProductService
{
    private readonly HttpClient _client;

    public AliExpressProductService()
    {
        _client = new HttpClient();

        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
        _client.DefaultRequestHeaders.Add("x-rapidapi-host", "aliexpress-true-api.p.rapidapi.com");
        _client.DefaultRequestHeaders.Add("x-rapidapi-key", "708b2a8b97msh1629e0bebcfc5fcp1aa461jsnf68afc6f5a0d");
    }

    public async Task<List<Product>> GetProducts(string search)
    {
        var url = new StringBuilder("https://aliexpress-true-api.p.rapidapi.com/api/v3/products?page_no=1&ship_to_country=UZ");
        if (!string.IsNullOrWhiteSpace(search))
        {
            url.Append($"&keywords={search}");
        }
        
        var response = await _client.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var root = JsonSerializer.Deserialize<AliResponseRoot>(json, options);

        if (root?.Products?.Product == null)
        {
            return new List<Product>();
        }

        return root.Products.Product.Select(item => new Product
        {
            Name = item.ProductTitle,
            Price = $"{item.TargetSalePrice} {item.TargetSalePriceCurrency}",
            Source = item.ProductMainImageUrl,
            Link = item.ProductDetailUrl
        }).ToList();
    }
}
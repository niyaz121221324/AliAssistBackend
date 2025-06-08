using System.Net.Http.Headers;
using AliAssistApp.Models;
using Newtonsoft.Json;

namespace AliAssistApp.Services;

public class AmazonAmazonProductService : IAmazonProductService
{
    private readonly HttpClient _client;

    public AmazonAmazonProductService()
    {
        _client = new HttpClient();
        // Устанавливаем заголовки для всех запросов
        _client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
        _client.DefaultRequestHeaders.Add("axesso-api-key", "72591da1c746451a804033145496a0c5");
    }

    public async Task<List<Product>> GetProducts(string query)
    {
        var baseUri = "https://api.axesso.de/amz/amazon-search-by-keyword-asin?domainCode=com&page=1&sortBy=relevanceblender";
        var keywordPart = !string.IsNullOrWhiteSpace(query) ? $"&keyword={Uri.EscapeDataString(query)}" : "";
        var uri = baseUri + keywordPart;

        try
        {
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching products: {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Десериализация JSON-ответа в объект AmazonResult
            var amazonResult = JsonConvert.DeserializeObject<AmazonResult>(jsonResponse);

            // Создаем список продуктов, используя данные из AmazonResult
            var products = new List<Product>();
            foreach (var productDetail in amazonResult.SearchProductDetails)
            {
                products.Add(new Product
                {
                    Name = productDetail.ProductDescription,
                    Price = productDetail.Price.ToString(),
                    Source = productDetail.ImgUrl,  // Ссылка на изображение товара (по вашему выбору)
                    Link = productDetail.DpUrl     // Ссылка на страницу товара
                });
            }

            return products;
        }
        catch (Exception ex)
        {
            // Обработка ошибок (например, сетевых ошибок)
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }
}
using AliAssistApp.Models;

namespace AliAssistApp.Services;

public interface IAmazonProductService
{
    Task<List<Product>> GetProducts(string query);
}
using AliAssistApp.Models;

namespace AliAssistApp.Services;

public interface IAliExpressProductService
{
    Task<List<Product>> GetProducts(string query);
}
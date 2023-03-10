namespace EcomSite.Server.Services.ProductService
{
  public interface IProductService
  {
    Task<ServiceResponse<List<Product>>> GetProductAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int produtcId);
    Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
    Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
    Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
  }
}

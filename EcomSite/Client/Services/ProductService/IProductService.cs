namespace EcomSite.Client.Services.ProductService
{
  public interface IProductService
    {
    string message { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public string LastSearchText { get; set; }
    event Action ProductsChanged;
    List<Product> Products { get; set; }
    Task GetProducts(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task SearchProducts(string searchText, int page);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
  }
}

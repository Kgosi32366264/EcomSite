namespace EcomSite.Client.Services.ProductService
{
  public class ProductService: IProductService
  {
    public event Action ProductsChanged;
    private readonly HttpClient _httpClient;
    public List<Product> Products { get; set; } = new();
    public string message { get; set; } = "Loading Products...";
    public int CurrentPage { get; set; } = 1;
    public int PageCount { get; set; } = 0;
    public string LastSearchText { get; set; } = string.Empty;

    public ProductService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task GetProducts(string? categoryUrl = null)
    {
      var result = categoryUrl == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");

      if (result != null && result.Data != null)
        Products = result.Data;

      CurrentPage = 1;
      PageCount = 0;

      if (Products.Count == 0)
        message = "No Products found";

      ProductsChanged?.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
      var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
      return result;
    }

    public async Task SearchProducts(string searchText, int page)
    {
      LastSearchText = searchText;
      var result = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");

      if (result != null && result.Data != null)
      {
        Products = result.Data.Products;
        CurrentPage = result.Data.CurrentPage;
        PageCount = result.Data.Pages;  
      } 

      if (Products.Count == 0)message = "No Products found.";
      ProductsChanged?.Invoke();
    }

    public async Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
      var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/search/{searchText}");
      return result.Data;
    }
  }
}

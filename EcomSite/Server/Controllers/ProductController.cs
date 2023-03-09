using EcomSite.Server.Services.CatergoryService;
using EcomSite.Server.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace EcomSite.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    private readonly ICatergoryService _catergoryService;
    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
      var result = await _productService.GetProductAsync();
      return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
    {
      var result = await _catergoryService.GetCategoryAsync();
      return Ok(result);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProducts(int productId)
    {
      var result = await _productService.GetProductAsync(productId);
      return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductByCategory(string categoryUrl)
    {
      var result = await _productService.GetProductByCategory(categoryUrl);
      return Ok(result);
    }

    [HttpGet("search/{searchText}/{page}")]
    public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
    {
      var result = await _productService.SearchProducts(searchText, page);
      return Ok(result);
    }

    [HttpGet("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
    {
      var result = await _productService.GetProductSearchSuggestions(searchText);
      return Ok(result);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
    {
      var result = await _productService.GetFeaturedProducts();
      return Ok(result);
    }
  }
}

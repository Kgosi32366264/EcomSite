using EcomSite.Server.Services.CatergoryService;
using Microsoft.AspNetCore.Mvc;

namespace EcomSite.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatergoryController : ControllerBase
  {
    private readonly ICategoryService _catergoryService;

    public CatergoryController(ICategoryService catergoryService)
    {
      _catergoryService = catergoryService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
    {
      var result = await _catergoryService.GetCategoryAsync();
      return Ok(result);
    } 

    //[HttpGet("{categoryId}")]
    //public async Task<ActionResult<ServiceResponse<Category>>> GetCategoriesAsync(int categoryId)
    //{
    //  var result = await _catergoryService.GetCategoryAsync(categoryId);
    //  return Ok(result);
    //}
  }
}

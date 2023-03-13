namespace EcomSite.Server.Services.CatergoryService
{
  public interface ICategoryService
  {
    Task<ServiceResponse<List<Category>>> GetCategoryAsync();
    //Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId);
  }
}

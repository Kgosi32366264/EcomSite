namespace EcomSite.Server.Services.CatergoryService
{
  public interface ICatergoryService
  {
    Task<ServiceResponse<List<Category>>> GetCategoryAsync();
    //Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId);
  }
}

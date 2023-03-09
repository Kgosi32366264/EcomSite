using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EcomSite.Client.Services.AuthService
{
  public class AuthService : IAuthService
  {
    private readonly HttpClient _httpClient;
    public AuthService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<ServiceResponse<int>> Register(UserRegister userRequest)
    {
      var result = await _httpClient.PostAsJsonAsync("api/auth/register", userRequest);

      var response = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
      return response; 
    }

    //  public async Task<ServiceResponse<int>> Register(UserRegister userRequest)
    //  {
    //    var content = new StringContent(JsonConvert.SerializeObject(userRequest));
    //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

    //    var response = await _httpClient.PostAsync("api/auth/register", content);
    //    response.EnsureSuccessStatusCode();
    //    return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    //  }
  }
}

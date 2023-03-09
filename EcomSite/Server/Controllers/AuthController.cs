using EcomSite.Server.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace EcomSite.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody]UserRegister userRegister)
    {
      var response = await _authService.Register(new User { Email = userRegister.Email }, userRegister.Password);

      if(!response.Success)
        return BadRequest(response);

      return Ok(response);
    }
  }
}
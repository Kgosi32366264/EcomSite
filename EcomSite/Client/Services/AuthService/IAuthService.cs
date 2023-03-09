﻿using Microsoft.AspNetCore.Mvc;

namespace EcomSite.Client.Services.AuthService
{
  public interface IAuthService
  {
    Task<ServiceResponse<int>> Register(UserRegister request);
  }
}
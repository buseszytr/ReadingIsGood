using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.API.Resources;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;

namespace ReadingIsGood.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            AccessTokenResponse accessToken =
                authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);

            if (accessToken.Success)
            {
                return Ok(accessToken.accessToken);
            }

            return BadRequest(accessToken.Message);
        }
    }
}

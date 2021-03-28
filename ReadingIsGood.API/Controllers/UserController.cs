using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ReadingIsGood.API.Resources;
using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;

namespace ReadingIsGood.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

            UserResponse userResponse = userService.FindById(int.Parse(userId));

            if (userResponse.Success)
            {
                return Ok(userResponse.user);
            }

            return BadRequest(userResponse.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser(UserResource userResource)
        {
            User user = mapper.Map<UserResource, User>(userResource);

            UserResponse userResponse = userService.AddUser(user);

            if (userResponse.Success)
            {
                return Ok(userResponse.user);
            }

            return BadRequest(userResponse.Message);
        }
    }
}

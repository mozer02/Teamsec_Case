using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Application.services.abstraction;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("AddedUserFavoriteMovie")]
        public ActionResult<bool> AddedUserFavoriteMovie([FromQuery] int userId, [FromQuery] int movieId)
        {
            return _userService.AddedUserFavoriteMovie(userId, movieId);
        }
        [HttpGet("GetUserFavoriteMovies")]
        public List<MoviesResponseDto> GetUserFavoriteMovies([FromQuery] int userId)
        {
            return _userService.GetUserFavoriteMovies(userId);
        }
        [HttpDelete("DeleteUserFavoriteMovie")]
        public ActionResult<bool> DeleteUserFavoriteMovie([FromQuery] int userId, [FromQuery] int movieId)
        {
            return _userService.DeleteUserFavoriteMovie(userId, movieId);
        }

    }
}

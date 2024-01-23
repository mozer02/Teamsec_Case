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
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddMovie")]
        public ActionResult<bool> AddMovie([FromBody] AddMovieRequestDto movie)
        {
            return _movieService.AddMovie(movie);
        }
        [HttpPut("UpdateMovie")]
        public ActionResult<bool> UpdateMovie([FromBody] UpdateMovieRequestDto movie)
        {
            return _movieService.UpdateMovie(movie);
        }
        [HttpGet("GetAll")]

        public List<Movie> GetAll()
        {
            return _movieService.GetAll();
        }
        [HttpDelete("DeleteMovie")]
        public ActionResult<bool> DeleteMovie([FromQuery] int movieId)
        {
            return _movieService.DeleteMovie(movieId);
        }
        [HttpGet("GetUsersWhoFavoritedTheMovie")]
        public List<FavoriteUserDto> GetUsersWhoFavoritedTheMovie([FromQuery] int movieId)
        {
            return _movieService.GetUsersWhoFavoritedTheMovie(movieId);
        }
    }
}

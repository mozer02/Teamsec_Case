using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Application.services.abstraction;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;

namespace Teamsec_Case.Application.services.concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public UserService(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public bool AddedUserFavoriteMovie(int userId, int movieId)
        {
            var user = _userRepository.GetQuery(t => t.Id == userId).Include(t => t.Favorites).FirstOrDefault();
            var movie = _movieRepository.GetQuery(t => t.Id == movieId).FirstOrDefault();
            if (user != null && movie != null)
            {
                var isMovie = user.Favorites.Select(t => t.Movie).Contains(movie);
                if (!isMovie)
                {
                    var favorite = new Favorite
                    {
                        Movie = movie,
                        User = user
                    };
                    user.Favorites.Add(favorite);
                    _userRepository.Update(user);
                    _userRepository.Save();
                }
                return true;
            }

            return false;
        }

        public bool DeleteUserFavoriteMovie(int userId, int movieId)
        {
            var user = _userRepository.GetQuery(t => t.Id == userId).Include(t => t.Favorites).FirstOrDefault();
            if (user != null)
            {
                var favorite = user.Favorites.Where(t => t.MovieId == movieId).FirstOrDefault();
                if (favorite != null)
                {
                    user.Favorites.Remove(favorite);
                    _userRepository.Update(user);
                    _userRepository.Save();
                }
                return true;
            }
            return false;
        }

        public List<MoviesResponseDto> GetUserFavoriteMovies(int userId)
        {
            var moviesResponseDto = new List<MoviesResponseDto>();
            var user = _userRepository.GetQuery(t => t.Id == userId).Include(t => t.Favorites).ThenInclude(t => t.Movie).FirstOrDefault();
            if (user != null)
            {
                var movies = user.Favorites.Select(t => t.Movie).ToList();
                foreach (var movie in movies)
                {
                    moviesResponseDto.Add(new MoviesResponseDto
                    {
                        Id = movie.Id,
                        Actors = movie.Actors,
                        Description = movie.Description,
                        ImdbPoint = movie.ImdbPoint,
                        Name = movie.Name
                    });
                }

                return moviesResponseDto;
            }
            return moviesResponseDto;
        }
    }
}

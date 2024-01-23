using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Application.services.abstraction;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;

namespace Teamsec_Case.Application.services.concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public bool AddMovie(AddMovieRequestDto movie)
        {
            var movieModel = new Movie
            {
                Name = movie.Name,
                Description = movie.Description,
                Actors = movie.Actors,
                ImdbPoint = movie.ImdbPoint,
                IsActive = true,
                IsDeleted = false,
                CreateDate = DateTime.Now
            };
            _movieRepository.Add(movieModel);
            _movieRepository.Save();
            return true;

        }

        public bool DeleteMovie(int movieId)
        {
            try
            {
                var movie = _movieRepository.GetQuery(t => t.Id == movieId).FirstOrDefault();
                if (movie != null)
                {
                    _movieRepository.Remove(movieId);
                    _movieRepository.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateMovie(UpdateMovieRequestDto movie)
        {
            try
            {
                var movieModel = _movieRepository.GetQuery(t => t.Id == movie.Id).FirstOrDefault();
                if (movie != null)
                {
                    movieModel.Actors = movie.Actors;
                    movieModel.Description = movie.Description;
                    movieModel.Name = movie.Name;
                    movieModel.ImdbPoint = movie.ImdbPoint;
                    movieModel.UpdateDate = DateTime.Now;
                    _movieRepository.Update(movieModel);
                    _movieRepository.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Movie> GetAll()
        {
            var listMovies = _movieRepository.GetAll();
            return listMovies.ToList();
        }

        public List<FavoriteUserDto> GetUsersWhoFavoritedTheMovie(int movieId)
        {
            var favoriteUser = new List<FavoriteUserDto>();
            var movie = _movieRepository.GetQuery(t => t.Id == movieId).Include(t => t.Favorites).ThenInclude(t => t.User).FirstOrDefault();
            if (movie != null)
            {
                var users = movie.Favorites.Select(t => t.User).ToList();
                foreach (var user in users)
                {
                    favoriteUser.Add(new FavoriteUserDto
                    {
                        UserId = user.Id,
                        Username = user.Username,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email
                    });
                }

                return favoriteUser;
            }
            return favoriteUser;

        }
    }
}

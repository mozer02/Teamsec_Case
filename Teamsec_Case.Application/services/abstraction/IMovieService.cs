using System.Collections.Generic;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.Application.services.abstraction
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        bool AddMovie(AddMovieRequestDto movie);
        bool DeleteMovie(int movieId);
        bool UpdateMovie(UpdateMovieRequestDto movie);
        List<FavoriteUserDto> GetUsersWhoFavoritedTheMovie(int movieId);
    }
}

using System.Collections.Generic;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.Application.services.abstraction
{
    public interface IUserService
    {
        bool AddedUserFavoriteMovie(int userId, int movieId);
        bool DeleteUserFavoriteMovie(int userId, int movieId);
        List<MoviesResponseDto> GetUserFavoriteMovies(int userId);
    }
}

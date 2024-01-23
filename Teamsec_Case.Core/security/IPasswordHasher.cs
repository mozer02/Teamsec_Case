namespace Teamsec_Case.Core
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}

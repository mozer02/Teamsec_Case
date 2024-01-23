using Teamsec_Case.Core;
using System.Collections.Generic;

namespace Teamsec_Case.Domain.models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}

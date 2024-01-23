using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsec_Case.Core;

namespace Teamsec_Case.Domain.models
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? ImdbPoint { get; set; }
        public string? Actors { get; set; }
        public List<Favorite> Favorites { get; set; }

    }
}

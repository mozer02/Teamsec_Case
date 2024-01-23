using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsec_Case.Application.dtos
{
    public class AddMovieRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ImdbPoint { get; set; }
        public string Actors { get; set; }
    }
}

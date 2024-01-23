namespace Teamsec_Case.Application.dtos
{
    public class MoviesResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? ImdbPoint { get; set; }
        public string? Actors { get; set; }
    }
}

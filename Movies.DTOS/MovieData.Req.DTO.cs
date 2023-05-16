namespace Movies.DTOS
{
    public class MovieDataRequestDTO
    {
        public string Title { get; set; }   
        public bool OnBillboard { get; set; }   
        public string PosterUrl { get; set; }   
        public string ReleaseDate { get; set; }   
        public List<int> Genres { get; set; }
        public List<MoviesActorRequestDTO> Actors { get; set; }   
        public List<int> MovieRooms { get; set; }
    }
}

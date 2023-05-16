﻿namespace Movies.Entities.Movies
{
    public class MovieTheaterOffer
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentaje { get; set; }
        public int MovieTheaterId { get; set; }
    }
}

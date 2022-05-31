﻿using APIs.Models;

namespace APIs.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public int Limit { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }

    }
}
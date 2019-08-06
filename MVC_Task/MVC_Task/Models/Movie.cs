using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Task.Models
{
    public class Movie
    {
        public long Vote_Count { get; set; }
        public long Id { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public OriginalLanguage OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public List<long> GenreIds { get; set; }
        public string BackdropPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_Date { get; set; }

    }
    public enum OriginalLanguage { En, Ja, Ta };
    public class Result
    {
        public long Page { get; set; }
        public long TotalResults { get; set; }
        public long TotalPages { get; set; }
        public List<Movie> Results { get; set; }
    }

}
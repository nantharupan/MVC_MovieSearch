using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Movie
    {
        public string MovieName { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Stars { get; set; }
        public int ReleasedYear { get; set; }
        public Decimal Rating { get; set; }
        public Uri ThumbilImage { get; set; }
        public string Description { get; set; }

        public Movie()
        {

        }

        public Movie(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["MovieName"];
            MovieName = (string)jUser["MovieName"];
            Description = (string)jUser["Description"];
          
        }
    }

    public class Movies
    {
        public Movies ()
        {
            this.movies = new List<Movie>();
        }

        public List<Movie> movies { get; set; }
    }
}
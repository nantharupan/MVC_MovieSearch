using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.API.Models
{
    /// <summary>
    /// Movie class
    /// </summary>
    public class Movie
    {
        public string MovieName { get; set; }
        public string id { get; set; }
        public List<Person> Actors { get; set; }
        public List<Person> Stars { get; set; }
        public int ReleasedYear { get; set; }
        public string Rating { get; set; }
        public Uri ThumbilImage { get; set; }
        public string Description { get; set; }
        public string YouTubeId { get; set; }
    }
}
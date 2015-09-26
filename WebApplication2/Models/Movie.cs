using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.API.Models
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
    }
}
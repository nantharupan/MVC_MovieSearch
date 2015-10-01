using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace Web.API.Models
{
    /// <summary>
    /// DetailMovie Class
    /// It is the model defining the Detail description of the movie, which is extended the Movie Class
    /// </summary>
    public class DetailMovie : Movie
    {
        public List<Person> DirectorName { get; set; }
        public List<Person> ProducerName { get; set; }
        public string ProducingCompanyName { get; set; }
        public string ReleasingCompanyName { get; set; }
        public string TrailerURL { get; set; }
        public List<Comment> PublicComments { get; set; }
        public string Length { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public List<Person> Writers { get; set; }
        public string StoryLine { get; set; }
        public List<Person> MusicDirectorName { get; set; }
        public bool isMovie { get; set; }
        public string NumberOfVotes { get; set; }


    }
}
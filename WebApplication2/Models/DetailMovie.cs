using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.API.Models
{
    public class DetailMovie
    {
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string ProducerName { get; set;}
        public string ProducingCompanyName {get;set;}
        public string ReleasingCompanyName {get;set;}
        public List<string> Actors{ get; set; }
        public List<string> Stars { get; set; }
        public int ReleasedYear{ get; set; }
        public Uri TrailerURL { get; set; }
        public Decimal Rating { get; set; }
        public List<string> PublicComments { get; set; }
        public Uri ThumbilImage { get; set; }
        public string Length { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public List<string> Writers { get; set; }
        public string Description { get; set; }
        public string StoryLine { get; set; }

      
    }
}
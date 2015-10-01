using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.API.Models;
using Web.API.Service;
using WebApplication2.Models;

namespace Web.API.Controllers
{
    public class MovieController : ApiController
    {
        private MovieSearchService moviewSearchService;

        public List<Movie> Get(string name)
        {
            return moviewSearchService.GetMovies(name);
        }

        public DetailMovie GetMovie(string IMDBid, string youTubeID)
        {
            return moviewSearchService.GetMovie(IMDBid, youTubeID);
        }

        public MovieController ()
        {
            this.moviewSearchService = new MovieSearchService();
        }

    }
}

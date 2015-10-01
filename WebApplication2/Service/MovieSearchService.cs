using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using Web.API.Helpers;
using Web.API.Models;
using WebApplication2.Models;


namespace Web.API.Service
{
    /// <summary>
    /// MovieSearchService Class
    /// </summary>
    public class MovieSearchService
    {
        /// <summary>
        /// Search Service to find the detail of the movie based on the movie id or movie name.
        /// </summary>
        /// <param name="searchString">The search string</param>
        /// <param name="d">The id of the Movie which is used to find the moview, which is part of the Movie data base provider</param>
        /// <returns>Get the whole detail about the movie</returns>
        /// TO-DO : Method should be implemented
        public DetailMovie GetMovie(string IMDBid,string youTubeID)
        {
            Helper helper = new Helper();
            String jsonResponse = helper.GerDetailMovieJSON(IMDBid);

            DetailMovie m = helper.ParseJSONtoMovie(jsonResponse, youTubeID);

            return m;
        }

        /// <summary>
        /// Search Service to find list of movies associated with the search string
        /// </summary>
        /// <param name="searchString">The search string</param>
        /// <returns>List of Movies associated with the search string</returns>
        public List<Movie> GetMovies(string searchString)
        {
           Helper helper = new Helper();

           String jsonResponse = helper.GetSearchJSONResults(searchString);  // Get the JSON String from the IMDB un official API

           List<Movie> searchResults = helper.ParseJSONtoMovieList(jsonResponse); //Parse the JSON and create a list of Movie

           List<YouTubeModel> searchYouTubeResults = helper.GetYTResults(searchString); //Get the List of YouTubeModel for the same search string

           // Compare the two list of results and match the movie based on title and set the Thumbnal, Vidoe ID and description
           foreach (var m in searchResults)
           {
               foreach (var ym in searchYouTubeResults)
               {
                   if (ym.Title.Contains(m.MovieName))
                   {
                       m.ThumbilImage = ym.Thumbnal;
                       m.YouTubeId = ym.VideoId;
                       m.Description = ym.Description;
                       break;
                   }
               }
           }

           if (jsonResponse != null)
           {
               return helper.SortMovies(searchResults);  // Sort the movie to show the movies with video in first
           }else
           {
               return null;
           }


           


        }
    }
}
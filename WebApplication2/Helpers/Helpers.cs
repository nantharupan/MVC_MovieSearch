using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Web.API.Models;
using WebApplication2.Models;

namespace Web.API.Helpers
{
    /// <summary>
    /// Helpers class, which has the methods to Parse the JSON
    /// </summary>
    public class Helper
    {
        public List<Movie> ParseJSONtoMovieList(string JSONIMDB)
        {

            List<Movie> movieList = new List<Movie>();
            char[] delimiterChars = { ',', ' ', '/' };

            dynamic stuff = JsonConvert.DeserializeObject(JSONIMDB);

            var data_titlepopular = stuff.title_popular;
            var data_titleapprox = stuff.title_approx;

            var datarray="";

            if (data_titlepopular!=null)
            {
                foreach (var data in stuff.title_popular)
                {
                    string s = data.description;
                    string[] words = s.Split(delimiterChars);


                    Movie m = new Movie
                    {
                        id = data.id,
                        MovieName = data.title,
                        ReleasedYear = Convert.ToInt32(words[0]),
                    };
                    movieList.Add(m);
                }
            } else if(data_titleapprox!=null)
            {
                foreach (var data in stuff.title_approx)
                {
                    string s = data.description;
                    string[] words = s.Split(delimiterChars);


                    Movie m = new Movie
                    {
                        id = data.id,
                        MovieName = data.title,
                        ReleasedYear = Convert.ToInt32(words[0]),
                    };
                    movieList.Add(m);
                }
            }
            

          
            return movieList;
        }

        public string GetSearchJSONResults(string searchString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.imdb.com/xml/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string search = "find?json=1&nr=1&tt=on&q=" + searchString;

                var response = client.GetAsync(search).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Movie> SortMovies(List<Movie> movies)
        {
            return movies.OrderBy(o => o.Description).Reverse().ToList();
        }
        public List<YouTubeModel> GetYTResults(string searchString)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
           {
               ApiKey = "AIzaSyD9pT1ig_V3DrzF-9xTUENXyS3Nf7reWAk",
               ApplicationName = "Movie Search",
           });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchString;
            searchListRequest.MaxResults = 50;


            var searchListResponse = searchListRequest.Execute();  // instead of Aync Call, i used Sync call
            List<YouTubeModel> videos = new List<YouTubeModel>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(new YouTubeModel { Title = searchResult.Snippet.Title, Description = searchResult.Snippet.Description, VideoId = searchResult.Id.VideoId, Thumbnal = new Uri(searchResult.Snippet.Thumbnails.Medium.Url) });
                        break;

                }
            }
            return videos;

        }

        public List<YouTubeModel> GetYTResultsByYouTubeId(string youtubeid,string searchString)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyD9pT1ig_V3DrzF-9xTUENXyS3Nf7reWAk",
                ApplicationName = "Movie Search",
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchString;
            searchListRequest.Type = "video";
            searchListRequest.RelatedToVideoId = youtubeid;
            searchListRequest.MaxResults = 50;


            var searchListResponse = searchListRequest.Execute();  // instead of Aync Call, i used Sync call
            List<YouTubeModel> videos = new List<YouTubeModel>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(new YouTubeModel { Title = searchResult.Snippet.Title, Description = searchResult.Snippet.Description, VideoId = searchResult.Id.VideoId, Thumbnal = new Uri(searchResult.Snippet.Thumbnails.Medium.Url) });
                        break;

                }
            }
            return videos;
        }


        public DetailMovie ParseJSONtoMovie(string JSONIMDB,string youtubeId)
        {
            DetailMovie m= new DetailMovie();
            char[] delimiterChars = { ',', ' ', '/' };

            dynamic stuff = JsonConvert.DeserializeObject(JSONIMDB);

            var data = stuff.data;
            var directors = data.directors_summary;
            var casts = data.cast_summary;

            List<Person> MovieDirectors = new List<Person>();

            if (directors != null)
            {

                foreach (var d in directors)
                {
                    MovieDirectors.Add(new Person { Name = d.name.name, Id = d.name.nconst, });
                }
            }

            List<Person> MovieStars = new List<Person>();

            if (casts != null)
            {

                foreach (var c in casts)
                {
                    MovieStars.Add(new Person { Name = c.name.name, Id = c.name.nconst });
                }
            }
            Comment comment = new Comment();
            if (data.user_comment != null)
            {
               comment = new Comment { CommentByPublic = data.user_comment.summary, CommentedBy = data.user_comment.user_name, CommentedDate = data.user_comment.date };

            }
            

               
                   m.id = data.id;
                   m.MovieName = data.title;
                   m.ReleasedYear= data.year;
                    if(MovieDirectors.Count>0)
                    {
                        m.DirectorName = MovieDirectors;
                    }
                  
                   m.Description = data.trivium;
               //    m.StoryLine=data.trailer.description;

                    if(data.runtime!=null)
                    {
                        m.Length = data.runtime.time;
                 
                    }
                    m.NumberOfVotes = data.num_votes;
                   m.Rating = data.rating;
            if(MovieStars.Count>0)
            {
                m.Stars = MovieStars;

            }
               
            if(comment!=null)
            {
                m.PublicComments = new List<Comment> { comment };

            }
               
               
           if(youtubeId!=null)
           {
               m.YouTubeId=youtubeId;

           }
           else
           {
               if (data.trailer != null)
               {
                   m.StoryLine = data.trailer.description;
                   string dd = "HD 480p";
                   m.TrailerURL = data.trailer.encoding.dd.url;
               }
           }


           List<YouTubeModel> youtubemovies = new List<YouTubeModel>();
            youtubemovies = GetYTResultsByYouTubeId(youtubeId,m.MovieName);

            foreach(var movie in youtubemovies)
            {
                if(movie.VideoId==m.YouTubeId)
                {
                    m.YouTubeId = movie.VideoId;
                    m.ThumbilImage = movie.Thumbnal;
                    break;
                }else if(movie.Title.Contains(m.MovieName))
                {
                    m.YouTubeId = movie.VideoId;
                    m.ThumbilImage = movie.Thumbnal;
                }
                else if(movie.Description.Contains(m.MovieName))
                {
                    m.YouTubeId = movie.VideoId;
                    m.ThumbilImage = movie.Thumbnal;
                }
            }

         

            return m;
            
        }

        public string GerDetailMovieJSON(string IMDBid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://app.imdb.com/title/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string search = "maindetails?tconst=" + IMDBid;

                var response = client.GetAsync(search).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }



}
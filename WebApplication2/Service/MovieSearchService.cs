using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using Web.API.Models;
using WebApplication2.Models;

namespace Web.API.Service
{
    public class MovieSearchService
    {
        public DetailMovie GetMovie(string Moviename)
        {
            return new DetailMovie
                {
                    MovieName="AAAAAAAAAAAA",
                    DirectorName="Steven Spielberg",
                    Description="During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                    Country="USA",
                    Language="English",
                    Length="127 min",
                    Rating=new decimal(8.1),
                    ProducerName="Kathleen Kennedy",
                    ProducingCompanyName="Rick Carter",
                    ThumbilImage= new Uri("http://ia.media-imdb.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_UX67_CR0,0,67,98_AL_.jpg"),
                    TrailerURL= new Uri("http://www.imdb.com/rg/VIDEO_PLAY/LINK//video/imdb/vi177055257/"),
                    ReleasedYear=1993,
                    Actors= new List<string>(){ "Sam Neill", "Jeff Goldblum", "Bob Peck", },
                    Stars =new List<string>(){" Jeff Goldblum"," Sam Neill"},
                    Writers= new List<string>(){"Michael Crichton","Michael Crichton"},
                    PublicComments = new List<string>(){},
                    ReleasingCompanyName="",
                
                 };
        }

        public idmbMovie[] GetMovies(string searchString)
        {
            List<idmbMovie> mo = new List<idmbMovie>();


            string responseString = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.imdb.com/xml/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("find?json=1&nr=1&tt=on&q=Jurasic").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                }
            }

            string jsonInput = responseString; //

            System.Console.Error.WriteLine(responseString);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            idmdMovieList m= jsonSerializer.Deserialize<idmdMovieList>(jsonInput);

           return m.title_popular.ToArray();




        /*    return new Movie[]{

                new Movie{
                     MovieName="JAAA",
                     Rating=new decimal(8.1),
                     Description="During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                   Actors= new List<string>(){ "Sam Neill", "Jeff Goldblum", "Bob Peck", },
                    Stars =new List<string>(){" Jeff Goldblum"," Sam Neill"},
               
                      ThumbilImage= new Uri("http://ia.media-imdb.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_UX67_CR0,0,67,98_AL_.jpg"),
                  ReleasedYear=1993,
                  

                },
                new Movie{
                       MovieName="Jurassic Park",
                     Rating=new decimal(8.1),
                     Description="During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                   Actors= new List<string>(){ "Sam Neill", "Jeff Goldblum", "Bob Peck", },
                    Stars =new List<string>(){" Jeff Goldblum"," Sam Neill"},
               
                      ThumbilImage= new Uri("http://ia.media-imdb.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_UX67_CR0,0,67,98_AL_.jpg"),
                  ReleasedYear=1993,
               
                }

            }; */
        }
    }
}
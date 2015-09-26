using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.API.Models;

namespace Web.API.Service
{
    public class MovieSearchService
    {
        public DetailMovie GetMovie(string Moviename)
        {
            return new DetailMovie
                {
                    MovieName="Jurassic Park",
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

        public Movie[] GetMovies(string searchString)
        {
            return new Movie[]{

                new Movie{
                     MovieName="Jurassic Park",
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

            };
        }
    }
}
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Movies movies = new Movies();

            Movie m = new Movie
            {
                MovieName = "Jurassic Park",
                Rating = new decimal(8.1),
                Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                Actors = new List<string>() { "Sam Neill", "Jeff Goldblum", "Bob Peck", },
                Stars = new List<string>() { " Jeff Goldblum", " Sam Neill" },

                ThumbilImage = new Uri("http://ia.media-imdb.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_UX67_CR0,0,67,98_AL_.jpg"),
                ReleasedYear = 1993,

            };
            movies.movies.Add(m);
            System.Diagnostics.Debug.WriteLine("TEST");
            string responseString = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51704/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/movie").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                }
            }

            System.Console.Write(responseString);
            System.Diagnostics.Debug.WriteLine(responseString);


            List<Movie> mo = new List<Movie>();
        //    mo.Add(m);
        //    mo.Add(m);
         //   mo.Add(m);
         //   mo.Add(m);
        //    mo.Add(m);
         //   mo.Add(m);

            return View(mo);
        }

        public ActionResult About( string searchString)
        {
            Movies movies = new Movies();

            Movie m = new Movie {
                MovieName = "Jurassic Park",
                Rating = new decimal(8.1),
                Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                Actors = new List<string>() { "Sam Neill", "Jeff Goldblum", "Bob Peck", },
                Stars = new List<string>() { " Jeff Goldblum", " Sam Neill" },

                ThumbilImage = new Uri("http://ia.media-imdb.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_UX67_CR0,0,67,98_AL_.jpg"),
                ReleasedYear = 1993,
            
            };
            movies.movies.Add(m);
            System.Diagnostics.Debug.WriteLine("TEST");

          
           List<Movie> mo = new List<Movie>();

            if(searchString=="A")
            {
                string responseString = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51704/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/movie?name=dfdf").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                    }
                }

             //   Movie m1 = new Movie(responseString);

                string jsonInput=responseString; //

                System.Console.Error.WriteLine(responseString);

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                mo= jsonSerializer.Deserialize<List<Movie>>(jsonInput);


             //   mo.Add(objCustomer);
            }else if(searchString=="AA")
            {
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
                mo.Add(m);
            }
            else
            {
             //   mo.Add(m);
                mo.Add(m);
            }

        //    mo.Add(m);
       //     mo.Add(m);
       //     mo.Add(m);
       //     mo.Add(m);
       //     mo.Add(m);
       //     mo.Add(m);


            return View(mo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

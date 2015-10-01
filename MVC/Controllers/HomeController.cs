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
           List<Movie> mo = new List<Movie>();
           return View(mo);
        }

        public ActionResult About(string searchString)
        {
            if(searchString=="" || searchString==null)
            {
                searchString = "Jurasic Park";
            }
          
           List<Movie> mo = new List<Movie>();

            
                string responseString = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51704/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/movie?name=" + searchString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                    }
                }

                string jsonInput=responseString; //

                System.Console.Error.WriteLine(responseString);

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                mo= jsonSerializer.Deserialize<List<Movie>>(jsonInput);
            return View(mo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DetailMovie(string movieId,string youTubeId)
        {
            if (youTubeId == "" || youTubeId == null)
            {
                youTubeId = "";
            }

            DetailMovie movie = new Models.DetailMovie();

            string responseString = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51704/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/movie?IMDBid=" + movieId + "&YouTubeid=" + youTubeId).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                }
            }

            string jsonInput = responseString; //

            System.Console.Error.WriteLine(responseString);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            movie = jsonSerializer.Deserialize<DetailMovie>(jsonInput);

            return View(movie);
        }
    }
}

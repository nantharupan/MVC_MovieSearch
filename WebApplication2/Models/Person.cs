using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace Web.API.Models
{
    /// <summary>
    /// Person class, which is used to identify the persons, it can be used to model the actor, music director, director, casts
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Biography { get; set; }
        public string Nominations { get; set; }
        public string Character { get; set; }
        public List<Movie> Movies {get; set;}
    }
}
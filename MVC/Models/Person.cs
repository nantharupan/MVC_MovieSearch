using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Biography { get; set; }
        public string Nominations { get; set; }
        public string Character { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
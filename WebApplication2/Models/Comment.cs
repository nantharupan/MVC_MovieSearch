using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.API.Models
{
    /// <summary>
    /// Comment Class
    /// It is the model defining the Comments for each movie
    /// </summary>
    public class Comment
    {
        public string Comment { get; set; }
        public string CommentedBy { get; set; }
        public DateTime CommentedDate { get; set; }
    }
}
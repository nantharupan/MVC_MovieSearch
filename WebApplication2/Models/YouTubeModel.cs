﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class YouTubeModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Thumbnal { get; set; }
    }
}
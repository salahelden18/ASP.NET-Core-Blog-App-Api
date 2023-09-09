﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos.Blog
{
    public class BlogResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string BlogImage { get; set; }
    }
}

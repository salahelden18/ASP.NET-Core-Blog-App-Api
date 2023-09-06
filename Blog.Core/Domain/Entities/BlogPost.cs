using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.Entities
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string BlogImage { get; set; }
        // add the navigation props
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tags> Tags { get;}
        public virtual Author Author { get; set; }
    }
}

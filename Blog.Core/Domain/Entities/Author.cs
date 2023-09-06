using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        // adding list of followers and list of followed
        public virtual ICollection<Author>? Followers { get; set; } // by them
        public virtual ICollection<Author>? FollowedAuthors { get; set; } // by me 
        // list of post of each author
        public virtual ICollection<BlogPost>? BlogPosts { get; set; }
    }
}

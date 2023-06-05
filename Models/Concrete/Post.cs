using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Concrete
{
    public class Post
    {
        public Post()
        {
        }
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PageTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }

        public bool IsHaveImage { get; set; }

        public bool IsShowInMainPage { get; set; }


        public string ImageUrl { get; set; }
    }
}

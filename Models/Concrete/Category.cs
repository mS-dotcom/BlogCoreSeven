using System;
using System.ComponentModel.DataAnnotations;
using BlogCoreSeven.Models;

namespace Blog.Models.Concrete
{
    public class Category
    {
        public Category()
        {
        }

        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsHaveImage { get; set; }

        public string? ImageUrl { get; set; }

        public bool Display { get; set; }
    }
}

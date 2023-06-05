using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Concrete
{
    public class User
    {
        public User()
        {
        }

        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

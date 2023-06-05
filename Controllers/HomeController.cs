using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Concrete;
using BlogCoreSeven.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogCoreSeven.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context db = new Context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var posts = db.Posts.ToList();
            ViewBag.posts = posts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Blog(int id)
        {
            var post = db.Posts.FirstOrDefault(x=>x.PostId==id);
            return View(post);
        }
        [HttpGet]
        public IActionResult SendContact(ContactForm contactForm)
        {
            contactForm.PhoneNumber = "yok";
            db.ContactForms.Add(contactForm);
            db.SaveChanges();
            return Json("Success!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



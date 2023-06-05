using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogCoreSeven.Controllers
{
    public class AdminController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public AdminController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        Context db = new Context();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogCategories()
        {
            var model = db.Categories;
            return View(model);
        }
        public IActionResult AddBlogCategories()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlogCategory(string categoryName)
        {
            try
            {
                Category category = new Category();
                category.CategoryName = categoryName;
                category.Display = true;
                db.Add(category);
                db.SaveChanges();
                string res = "Success!";
                return Json(res);
            }
            catch (Exception ex)
            {
                string res = "Error!";
                return Json(res);
            }

        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var myModel = db.Categories.ToList();
            return Json(myModel);
        }
        [HttpGet]
        public IActionResult DeleteCategory(int CategoryId)
        {
            db.Categories.Remove(db.Categories.FirstOrDefault(x => x.CategoryId == CategoryId));
            db.SaveChanges();
            return RedirectToAction("BlogCategories", "Admin");
        }
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Post post, IFormFile ImageUrl,IFormCollection f1)
        {
            string isshowinmainpage=f1["IsShowInMainPage"].ToString();
            if (isshowinmainpage == "on")
            {
                post.IsShowInMainPage = true;
            }
            else
            {
                post.IsShowInMainPage = false;
            }
            string filePath = "";
            Random rnd = new Random();
            
            if (ImageUrl.Length > 0)
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "admin/postfolders");
                
                
                 filePath = Path.Combine(uploads, ImageUrl.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImageUrl.CopyToAsync(fileStream);
                }

            }
            
            post.IsHaveImage = true;
            post.ImageUrl = ImageUrl.FileName;
            post.Title = post.PageTitle;
            Context context = new Context();
            context.Posts.Add(post);
            context.SaveChanges();
            return View();
        }
        public IActionResult Blogs()
        {
            Context db = new Context();
            var posts = db.Posts.ToList();
             return View(posts);
        }
        public IActionResult ContactForms()
        {
            Context db = new Context();
            return View(db.ContactForms);
        }
        [HttpGet]
        public IActionResult DeleteContactForm(int contactId)
        {
            db.ContactForms.Remove(db.ContactForms.FirstOrDefault(x => x.ContactId== contactId));
            db.SaveChanges();
            return RedirectToAction("ContactForms", "Admin");
        }
        public IActionResult DeletePost(int PostId)
        {
            db.Posts.Remove(db.Posts.FirstOrDefault(x => x.PostId == PostId));
            db.SaveChanges();
            return RedirectToAction("Blogs", "Admin");
        }
        public IActionResult UpdatePost(int PostId)
        {
            var Post = db.Posts.FirstOrDefault(x => x.PostId == PostId);
            return View(Post);
        }
        [HttpPost]
        public IActionResult UpdatePost(Post post, IFormFile ImageUrl, IFormCollection f1)
        {
            Context myDB = new Context();
            string isshowinmainpage = f1["IsShowInMainPage"].ToString();
            if (isshowinmainpage == "on")
            {
                post.IsShowInMainPage = true;
            }
            else
            {
                post.IsShowInMainPage = false;
            }
            var blogpost = myDB.Posts.FirstOrDefault(x => x.PostId == post.PostId);
            blogpost.PageTitle = post.Title;
            blogpost.Title = post.Title;
            blogpost.Content = post.Content;
            blogpost.SeoKeyword = post.SeoKeyword;
            blogpost.SeoDescription = post.SeoDescription;
            blogpost.IsShowInMainPage = post.IsShowInMainPage;


            string filePath = "";

            try
            {
                if (ImageUrl.Length > 0)
                {
                    string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "admin/postfolders");


                    filePath = Path.Combine(uploads, ImageUrl.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageUrl.CopyToAsync(fileStream);
                    }
                    post.IsHaveImage = true;
                    post.ImageUrl = ImageUrl.FileName;
                }
            }
            catch (Exception ex)
            {
                post.IsHaveImage = true;
            }
            

            

            myDB.SaveChanges();
            return RedirectToAction("Blogs");

        }
    }
}
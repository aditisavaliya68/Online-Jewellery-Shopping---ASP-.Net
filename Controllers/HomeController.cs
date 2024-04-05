//using Gemify.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace Gemify.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        public IActionResult Gold()
//        {
//            return View();
//        }

//        public IActionResult Silver()
//        {
//            return View();
//        }

//        public IActionResult Diamond()
//        {
//            return View();
//        }

//        public IActionResult Rings()
//        {
//            return View();
//        }

//        public IActionResult Pandants()
//        {
//            return View();
//        }
//        public IActionResult Bracelet()
//        {
//            return View();
//        }
//        public IActionResult Earrings()
//        {
//            return View();
//        }

//        public IActionResult Account()
//        {
//            return View();
//        }

//        public IActionResult Cart()
//        {
//            return View();
//        }
//        public IActionResult Wishlist()
//        {
//            return View();
//        }

//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Login(string username, string password)
//        {
//            // Implement login logic here
//            return RedirectToAction("Index", "Home"); // Redirect to home page after login
//        }

//        [HttpGet]
//        public IActionResult Signup()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Signup(string username, string password)
//        {
//            // Implement signup logic here
//            return RedirectToAction("Login"); // Redirect to login page after signup
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // Other configuration

//            app.UseStaticFiles(); // This enables serving static files from the wwwroot folder
//        }

//    }
//}



using Gemify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Gemify.Controllers
{
    public class HomeController : Controller
    {
        private readonly GemifyContext context;
      

        public HomeController(GemifyContext context)
        {
            this.context = context;

        }



      
        public IActionResult Index()
        {
         
            return View();
        }


        
     





        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Gold()
        {
            return View();
        }

        public IActionResult Silver()
        {
            return View();
        }

        public IActionResult Diamond()
        {
            return View();
        }

        public IActionResult Rings()
        {
            return View();
        }

        public IActionResult Pandants()
        {
            return View();
        }
        public IActionResult Bracelet()
        {
            return View();
        }
        public IActionResult Earrings()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Cart()
        {
            var products = context.Products.ToList(); // Retrieve all products from the database

            return View(products);
        }
        public IActionResult Wishlist()
        {
            var products = context.Products.ToList(); // Retrieve all products from the database

            return View(products);
        }








        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteAll()
        {
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Users()
        {
            var users = context.Users.ToList();
            return View(users);
        }




        /*  [HttpPost]
          public Task<IActionResult> Gold(Product product)
          {

              if (ModelState.IsValid)
              {
                  context.Products.Add(product);
                  context.SaveChanges();
                  return Task.FromResult<IActionResult>(RedirectToAction("Cart")); // Redirect to home or wherever appropriate
              }
              return Task.FromResult<IActionResult>(View());
          }*/







        /*
                [HttpPost]
                public IActionResult AddToCart(Product product)
                {
                    if (ModelState.IsValid)
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home"); // Redirect to the homepage or any other page
                    }
                    // If model state is not valid, return to the same view with validation errors
                    return View(product);
                }*/


        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {







                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to the homepage or any other page
            }
            // If model state is not valid, return to the same view with validation errors
            return View(product);
        }















        public IActionResult Login()
        {
             if(HttpContext.Session.GetString("UserSession")!=null)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var u=context.Users.Where(x=>x.Username==user.Username && x.Password == user.Password).FirstOrDefault();
            {
                if (u != null)
                {
                    HttpContext.Session.SetString("UserSession",u.Username);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Failed";
                }

            }
            return View();
        }


        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User user)
        {
            if (ModelState.IsValid)
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync(); 
                TempData["Success"] = "Registerd Succesfully";
                return RedirectToAction("Login");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other configuration

            app.UseStaticFiles(); // This enables serving static files from the wwwroot folder
        }

    }
}

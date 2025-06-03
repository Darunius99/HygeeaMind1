using HygeeaMind.Data; 
using HygeeaMind.Models; 
using HygeeaMind.ViewModels; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Diagnostics; 

namespace HygeeaMind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; 

        
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<IActionResult> Index(string searchString)
        {
            
            var articles = from a in _context.Articles
                           select a;

            
            if (!String.IsNullOrEmpty(searchString))
            {
                
                articles = articles.Where(s => s.Title.Contains(searchString) || s.Content.Contains(searchString));
            }

            var specialists = await _context.Specialists.ToListAsync();
            var viewModel = new HomeViewModel
            {
                Articles = await articles.ToListAsync(), 
                Specialists = specialists,
                SearchString = searchString 
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult About()
        {
            return View();
        }

        
        public IActionResult Contact()
        {
            return View();
        }

      
        public IActionResult Chat()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
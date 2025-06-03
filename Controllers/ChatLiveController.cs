
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; 

namespace HygeeaMind.Controllers
{
    public class ChatLiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
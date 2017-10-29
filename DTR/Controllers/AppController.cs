using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DTR.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger _logger;

        public AppController(ILogger<AppController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

     

    }
}
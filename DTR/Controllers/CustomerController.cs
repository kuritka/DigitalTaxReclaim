using Microsoft.AspNetCore.Mvc;
using DTR.ViewModels;
using DTR.Services;
using DTR.Data;

namespace DTR.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IMailService _mailService;
        private readonly ReclaimContext _context;

        public CustomerController(IMailService mailServie, ReclaimContext context)
        {
            _mailService = mailServie;
            _context = context;
        }

        [HttpGet("reclaim")]
        public IActionResult EnterReclaim()
        {
            return View();
        }

        [HttpPost("reclaim")]
        public IActionResult EnterReclaim(ReclaimViewModel model)
        {
            ViewBag.UserMessage = string.Empty;
            if (ModelState.IsValid)
            {
                _mailService.Send("kuritka@gmail.com", "Reclaim added",model.Message);
                ViewBag.UserMessage = "Submitted";
                ModelState.Clear();
            }
            else
            {
               
            }
            return View();
        }
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dream_Properties.Models;
using Dream_Properties.Repository;
using System.Threading.Tasks;

namespace Dream_Properties.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactMessageRepository contactMessageRepository;

        public HomeController(IContactMessageRepository contactMessageRepository)
        {
            this.contactMessageRepository = contactMessageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ContactMessage contactMessage)
        {
            if (contactMessage == null || string.IsNullOrEmpty(contactMessage.Name))
            {
                return BadRequest(new { success = false, message = "Invalid input data." });
            }

            try
            {
                await contactMessageRepository.SaveContactMessages(contactMessage);

                return Ok(new { success = true, message = "Your message has been successfully saved." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Internal server error. Please try again later." });
            }
        }

        public IActionResult Privacy()
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














//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using Dream_Properties.Models;
//using Dream_Properties.Repository;

//namespace Dream_Properties.Controllers;

//public class HomeController : Controller
//{
//    private readonly IContactMessageRepository contactMessageRepository;

//    public HomeController(IContactMessageRepository contactMessageRepository)
//    {
//        this.contactMessageRepository = contactMessageRepository;
//    }
//    public IActionResult Index()
//    {
//        return View();
//    }

//    [HttpPost]
//    public async Task<IActionResult> SendMessage(string name, string email, string subject, string message)
//    {
//        var contactMessage = new ContactMessage
//        {
//            Name = name,
//            Email = email,
//            Subject = subject,
//            Message = message
//        };

//        await this.contactMessageRepository.SaveContactMessages(contactMessage);

//        return Json(new { success = true, responseText = "Your Message has been successfully saved" });
//    }
//    public IActionResult Privacy()
//    {
//        return View();
//    }

//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}
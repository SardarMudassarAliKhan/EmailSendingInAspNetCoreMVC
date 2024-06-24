using EmailSendingInAspNetCoreMVC.Sevices;
using EmailSendingInAspNetCoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmailSendingInAspNetCoreMVC.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(model.ToEmail, model.Subject, model.Message);
                ViewBag.Message = "Email sent successfully!";
            }
            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Net.Mail;

namespace Sistema_PetShop.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void Send()
        {

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("leobarbosa.ti@gmail.com");
            mailMessage.To.Add("leobarbosa.ti@gmail.com");
            mailMessage.Subject = "Teste";
            mailMessage.Body = "Texto aqui";

            SmtpClient smtpClient = new SmtpClient("smtpClient.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("leobarbosa.ti@gmail.com", "12394525TiDb");

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);


        }

    }
}
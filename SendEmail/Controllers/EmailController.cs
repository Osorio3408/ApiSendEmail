using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendEmail(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("yuliamwow@gmail.com", "nvgbxgokbeiqzjta"),
            EnableSsl = true
        };
        
        var mailMessage = new MailMessage
        {
            From = new MailAddress("yuliamwow@gmail.com"),
            To = { email },
            Subject = subject,
            Body = message
        };
        await client.SendMailAsync(mailMessage);
        return Ok();
    }
}
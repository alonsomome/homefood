using System.Threading.Tasks;

namespace HomeFood.Helpers
{
    public interface IEmailSender
    {
         Task SendEmailAsync(string email, string subject, string message);
    }
}
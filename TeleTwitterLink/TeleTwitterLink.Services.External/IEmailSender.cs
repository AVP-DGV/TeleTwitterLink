using System.Threading.Tasks;

namespace TeleTwitterLink.Services.External
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

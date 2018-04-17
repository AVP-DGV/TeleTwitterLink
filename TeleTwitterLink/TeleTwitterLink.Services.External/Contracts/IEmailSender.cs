using System.Threading.Tasks;

namespace TeleTwitterLink.Services.External.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

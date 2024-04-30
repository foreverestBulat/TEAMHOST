using WebTeamHost.App.DTOs.Email;

namespace WebTeamHost.App.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}

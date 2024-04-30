using WebTeamHost.Application.DTOs.Email;

namespace WebTeamHost.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}

using SkillSeek.Application.DTOs.Email;

namespace SkillSeek.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendEmail(EmailActionDto emailAction);
}
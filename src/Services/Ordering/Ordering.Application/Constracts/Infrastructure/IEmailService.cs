using Ordering.Application.Models;

namespace Ordering.Application.Constracts.Infrastructure;

public interface IEmailService
{
	Task<bool> SendEmailAsync(Email email);
}


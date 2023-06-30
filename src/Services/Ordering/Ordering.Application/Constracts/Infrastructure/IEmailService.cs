using Ordering.Application.Models;
using System.Threading.Tasks;

namespace Ordering.Application.Constracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
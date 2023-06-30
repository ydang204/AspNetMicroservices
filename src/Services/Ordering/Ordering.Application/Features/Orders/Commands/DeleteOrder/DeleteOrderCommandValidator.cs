using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(o => o.Id).GreaterThan(0).WithMessage("{Id} is a positive number.");
        }
    }
}
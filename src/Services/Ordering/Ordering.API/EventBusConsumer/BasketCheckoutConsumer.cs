using AutoMapper;
using EventBus.Message.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using System;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMapper mapper,
                                      IMediator mediator,
                                      ILogger<BasketCheckoutConsumer> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            _logger.LogInformation($"Start consume BasketCheckoutEvent {context.Message}");
            var command = _mapper.Map<CheckOutOrderCommand>(context.Message);
            var orderId = await _mediator.Send(command);
            _logger.LogInformation($"BasketCheckoutEvent consumed successfully. Created order id {orderId}");
        }
    }
}
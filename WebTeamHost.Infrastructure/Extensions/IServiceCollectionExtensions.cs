using Microsoft.Extensions.DependencyInjection;

using MediatR;

using WebTeamHost.Application.Interfaces;
using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Common.Interfaces;
using WebTeamHost.Infrastructure.Services;

namespace WebTeamHost.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>();
        }
    }
}
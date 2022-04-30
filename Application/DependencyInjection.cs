using Application.Items.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetItemByIdQuery.Handler).Assembly);
            services.AddAutoMapper(typeof(GetItemByIdQuery.Handler));

            return services;
        }
    }
}
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OP.Newshore.Application.Behaviours;
using System.Reflection;

namespace OP.Newshore.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        } 
    }
}
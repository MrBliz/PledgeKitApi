using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Validation;

namespace PledgeKit.Functions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkSqlServer()
                .AddDbContext<PledgeKitContext>((serviceProvider, options) =>
                {
                    options.UseSqlServer(Environment.GetEnvironmentVariable("PledgeKitDb",
                                             EnvironmentVariableTarget.Process) ?? throw new InvalidOperationException())
                        .UseInternalServiceProvider(serviceProvider);

                });

            serviceCollection.AddTransient<IEventExistsValidator, EventExistsValidator>();
        }
    }
}

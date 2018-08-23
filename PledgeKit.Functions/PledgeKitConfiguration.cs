using System;
using System.Net.Http;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PledgeKit.Core.Attendees.Commands;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Handlers;
using FunctionMonkey.FluentValidation;

namespace PledgeKit.Functions
{
    public class PledgeKitConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {          
            builder                    
                .Setup((serviceCollection, commandRegistry) =>
                {
                    commandRegistry.Discover<GetEventByIdHandler>();
                    serviceCollection.AddEntityFrameworkSqlServer()
                        .AddDbContext<PledgeKitContext>((serviceProvider, options) =>
                        {
                            options.UseSqlServer(Environment.GetEnvironmentVariable("PledgeKitDb",
                                                     EnvironmentVariableTarget.Process) ?? throw new InvalidOperationException())
                                .UseInternalServiceProvider(serviceProvider);

                        });

                })
                .AddFluentValidation()
                .OpenApiEndpoint(openApi => openApi
                    .Title("A Simple API")
                    .Version("0.0.0")
                    .UserInterface()
                )
                .Functions(functions => functions
                    .HttpRoute("/api/events", route => route
                        .HttpFunction<EventListQuery>(HttpMethod.Get)
                    )
                    .HttpRoute("/api/events", route => route
                        .HttpFunction<EventQuery>("/{id}", HttpMethod.Get)   
                    )
                    .HttpRoute("/api/events/{id}/attendees", route => route
                        .HttpFunction<EventAttendeeQuery>(HttpMethod.Get)
                    )
                    .HttpRoute("/api/events/{id}/payments", route => route
                        .HttpFunction<EventPaymentsQuery>( HttpMethod.Get)
                    )
                    .HttpRoute("/api/events/{id}/pledges", route => route
                        .HttpFunction<EventPledgesQuery>(HttpMethod.Get)
                    )
                    .HttpRoute("/api/attendees/{id}", route => route
                        .HttpFunction<AttendeeQuery>(HttpMethod.Get)
                    )
                );
        }
    }
}

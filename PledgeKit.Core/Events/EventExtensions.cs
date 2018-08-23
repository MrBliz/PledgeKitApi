using System.Linq;
using PledgeKit.Core.Events.Models;
using PledgeKit.Core.Projects;
using PledgeKit.Data;

namespace PledgeKit.Core.Events
{
    public static class EventExtensions
    {
        public static IQueryable<EventModel> BuildEventModel(this IQueryable<Event> events)
        {
            return events.Select(x => new EventModel
            {
                Name = x.Name,
                EventId = x.EventId,
                EventDate = x.EventDate,
                EntryFee = x.EntryFee,
                Target = x.Target,
                EventLevy = x.EventLevy,
                ProjectCount = x.EventProjects.Count(p => !p.Project.Deleted),
                Projects = x.EventProjects.Select(p => new ProjectModel
                {
                    ProjectId = p.ProjectId,
                    Name = p.Project.Name
                }).ToList(),
                PledgeCount = x.Pledges.Count,
                TotalPledged = x.Pledges.Sum(p => p.Amount),
                PaymentCount = x.Payments.Count,
                TotalPayments = x.Payments.Sum(p => p.Amount),
                TotalAttendees = x.EventAttendees.Count
            });

        }
    }
}

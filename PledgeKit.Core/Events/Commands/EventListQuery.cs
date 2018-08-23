using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Models;
using PledgeKit.Core.Shared;

namespace PledgeKit.Core.Events.Commands
{
    public class EventListQuery : ICommand<EventList> , IPageable, IFilterable
    {
        public int PageNumber { get; set; }
        public int PageSize {get; set; }
        public string Filter { get; set; }
        public bool Descending { get; set; }
        /// <summary>
        ///  Sortable Columns : Name, EventDate
        /// </summary>
        public string SortColumn { get; set; }
    }
}

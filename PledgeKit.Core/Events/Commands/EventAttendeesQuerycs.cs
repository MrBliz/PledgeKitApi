﻿using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Commands
{
    public class EventAttendeeQuery : EventId, ICommand<EventAttendees>
    {
        
    }
}
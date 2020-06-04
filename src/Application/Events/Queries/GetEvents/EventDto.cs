using System;
using Dynamic.Application.Common.Mappings;
using Dynamic.Domain.Entities;
using System.Collections.Generic;

namespace Dynamic.Application.Events.Queries.GetEvents
{
    public class EventDto : IMapFrom<Event>
{
        public int Id { get; set; }

        public string Name { get; set; }

        public string LocationStart { get; set; }

        public string LocationEnd { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

}
}

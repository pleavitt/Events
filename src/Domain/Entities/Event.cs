using Dynamic.Domain.Common;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Dynamic.Domain.Entities
{
  public class Event : AuditableEntity
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string LocationStart { get; set; }

    public string LocationEnd { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string Description { get; set; }

    public int Capacity { get; set; }

    public IList<Attendee> Attendees { get; set; }

    public int attendance => Attendees.Select(x => x.Count).Sum();




  }
}

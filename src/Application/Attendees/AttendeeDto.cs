using System;
using Dynamic.Application.Common.Mappings;
using Dynamic.Domain.Entities;
using Dynamic.Application.Events.Queries.GetEvents;
using Dynamic.Application.Contacts.Queries.GetContacts;
namespace Dynamic.Application.Attendees
{
  public class AttendeeDto : IMapFrom<Attendee>
  {
    public int Id { get; set; }

    public ContactDto Client { get; set; }

    public int Guests { get; set; }

    public int Count { get; set; }


  }
}

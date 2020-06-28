using System;
using Dynamic.Application.Common.Mappings;
using Dynamic.Domain.Entities;

namespace Dynamic.Application.Contacts.Queries.GetContacts
{
  public class ContactDto : IMapFrom<Contact>
  {
    public string Name { get; set; }

    public string Company { get; set; }
  }
}

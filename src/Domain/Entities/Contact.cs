using Dynamic.Domain.Common;
using System;

namespace Dynamic.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public Attendee[] Attending { get; set; }
    }
}

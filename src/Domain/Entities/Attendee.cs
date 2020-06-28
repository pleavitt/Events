using Dynamic.Domain.Common;
using System;

namespace Dynamic.Domain.Entities
{
    public class Attendee : AuditableEntity
    {
        public int Id { get; set; }

        public Contact Client { get; set; }
        
        public int Guests { get; set; }

        public Event SpecialEvent { get; set; }

        public int Count => Guests + 1;

    }
}

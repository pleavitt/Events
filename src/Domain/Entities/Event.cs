using Dynamic.Domain.Common;
using System;

namespace Dynamic.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public string LocationStart { get; set; }

        public string LocationEnd { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        public String Description { get; set; }

        public int Capacity { get; set; }

        

    }
}

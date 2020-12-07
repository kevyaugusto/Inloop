using System;

namespace University.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

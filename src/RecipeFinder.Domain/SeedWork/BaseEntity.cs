using System;

namespace RecipeFinder.Domain.SeedWork
{
    public abstract class BaseEntity : Entity, IEntityKey<int>, ISoftDelete, IAuditableEntity
    {
        public int Id { get; set; }
        public int RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
    }
}

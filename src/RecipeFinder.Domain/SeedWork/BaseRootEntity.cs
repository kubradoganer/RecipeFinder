using System;

namespace RecipeFinder.Domain.SeedWork
{
    public abstract class BaseRootEntity : Entity, IEntityKey<Guid>, ISoftDelete, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
    }
}

using System;

namespace RecipeFinder.Domain.SeedWork
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        Guid CreatedByUserId { get; set; }
        DateTime UpdatedDate { get; set; }
        Guid UpdatedByUserId { get; set; }
    }
}

using RecipeFinder.Domain.Exceptions;
using System.Collections.Generic;

namespace RecipeFinder.Domain.SeedWork
{
    public abstract class Entity
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}

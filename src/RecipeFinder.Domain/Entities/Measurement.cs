﻿using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class Measurement : BaseRootEntity
    {
        public Measurement(Guid id, string name)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
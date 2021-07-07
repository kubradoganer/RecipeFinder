using RecipeFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RecipeFinder.Api
{
    internal class Assemblies
    {
        public static readonly Assembly Api = typeof(Startup).Assembly;
        public static readonly Assembly Application = typeof(Application.StartupExtensions).Assembly;
        public static readonly Assembly Domain = typeof(Recipe).Assembly;
        public static readonly Assembly Infrastructure = typeof(Infrastructure.StartupExtensions).Assembly;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.SearchRecipe
{
    public class SearchRecipeQuery
    {
        public string Name { get; set; }
        public string RecipeType { get; set; }
        public string Ingredient { get; set; }
        public string Measurement { get; set; }
    }
}

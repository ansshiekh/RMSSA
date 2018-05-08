using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSSA
{
    public class RecipeClass
    {
        public int RecipeId { get; set; }
        public String RecipeName { get; set; }
        public String RecipeSubtitle { get; set; }
        public Double RecipeRating { get; set; }
        public String RecipeDescription { get; set; }
        public String RecipeTime { get; set; }
        public String RecipeDifficulty { get; set; }
        public int RecipeUserId { get; set; }

    public RecipeClass()
        {

        }
    }
}

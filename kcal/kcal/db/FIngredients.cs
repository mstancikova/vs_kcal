using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcal.db
{
    public class FIngredients
    {
        public int ID { get; set; }
        public int FK_FoodID { get; set; }
        public int FK_IngredientID { get; set; }     /* then we take ingredient IName, IKcalg where this id */
        public double Quantity { get; set; }
        public double Kcals { get; set; }             /* summary of Ingredients.IKcalg per FI_Quantity */
    }
}

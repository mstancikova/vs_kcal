using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kcal.db
{
    public class Model
    {
        #region singleton
        private static Model instance;

        //singleton need private ctor
        private Model()
        {
        }

        public static Model getInstance()
        {
            if (instance == null)
            {
                instance = new Model();
            }
            return instance;
        }
        #endregion
        #region dataFunctions
        public IList<Category> Categories
        {
            get
            {
                List<Category> tmp = new List<Category>();
                tmp.Add(new Category() { ID = 1, CName = "Zelenina" });
                tmp.Add(new Category() { ID = 2, CName = "Ovocie" });
                tmp.Add(new Category() { ID = 3, CName = "Mliecne vyrobky" });
                tmp.Add(new Category() { ID = 4, CName = "Maso" });
                return tmp;
            }

        }


        public IList<Ingredients> Ingredients
        {
            get
            {
                List<Ingredients> tmp = new List<Ingredients>();
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Zelenina", IName = "Mrkva", IKcalg = 0.35 });
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Zelenina", IName = "Zemiaky", IKcalg = 0.77 });
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Ovocie", IName = "Jablko", IKcalg = 0.45 });
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Ovocie", IName = "Pomaranc", IKcalg = 0.34 });
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Mliecne vyrobky", IName = "Mlieko ciastocne odtucnene", IKcalg = 0.48 });
                tmp.Add(new Ingredients() { ID = 1, FK_CID = "Mliecne vyrobky", IName = "Maslo", IKcalg = 7.5 });
                return tmp;
            }
        }

        public IList<Foods> Foods
        {
            get
            {
                List<Foods> tmp = new List<Foods>();
                tmp.Add(new Foods() { ID = 1, FName = "Zemiakova", FKcalg = 0.85 });
                tmp.Add(new Foods() { ID = 1, FName = "Zeleninova polievka", FKcalg = 0.25 });
                return tmp;
            }
        }

        public IList<FIngredients> FoodIngredients
        {
            get
            {
                List<FIngredients> tmp = new List<FIngredients>();
                tmp.Add(new FIngredients() { ID = 1, FK_FoodID = 1, FK_IngredientID = 1, FI_Quantity = 100, FI_Kcal = 350 });
                return tmp;
            }
        }
        #endregion
    }
}

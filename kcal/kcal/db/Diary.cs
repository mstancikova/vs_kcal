using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcal.db
{
    public class Diary
    {
        private string _Entry = null;
        private int? _FK_IngredientID = null;
        private int? _FK_FoodID = null;

        public int ID { get; set; }
        public string Date { get; set; }
        public int? FK_IngredientID
        {
            get { return _FK_IngredientID; }
            set
            {
                if (_FK_IngredientID != value)
                {
                    _FK_IngredientID = value;
                    _Entry = Model.Instance.getIngredientNameById(FK_IngredientID ?? 0);
                }
            }
        }
        public int? FK_FoodID
        {
            get { return _FK_FoodID; }
            set
            {
                if (_FK_FoodID != value)
                {
                    _FK_FoodID = value;
                    _Entry = Model.Instance.getFoodNameById(FK_FoodID ?? 0);
                }
            }
        }
        public string Entry
        {
            get
            {
                if (Entry == null)
                {
                    if (FK_FoodID != null)
                    {
                        _Entry = Model.Instance.getFoodNameById(FK_FoodID ?? 0);
                    }
                    else
                    {
                        _Entry = Model.Instance.getIngredientNameById(FK_IngredientID ?? 0);
                    }
                }

                return _Entry;
            }
        }
        public string DQuantity { get; set; }
    }
}

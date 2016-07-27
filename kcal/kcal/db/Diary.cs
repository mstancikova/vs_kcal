using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcal.db
{
    public class Diary
    {
        private string _DEntry = null;
        private int? _FK_IngredientID = null;
        private int? _FK_FoodID = null;

        public int ID { get; set; }
        public string DDate { get; set; }
        public int? FK_IngredientID
        {
            get { return _FK_IngredientID; }
            set
            {
                if (_FK_IngredientID != value)
                {
                    _FK_IngredientID = value;
                    _DEntry = Model.Instance.getIngredientNameById(FK_IngredientID ?? 0);
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
                    _DEntry = Model.Instance.getFoodNameById(FK_FoodID ?? 0);
                }
            }
        }
        public string DEntry
        {
            get
            {
                if (_DEntry == null)
                {
                    if (FK_FoodID != null)
                    {
                        _DEntry = Model.Instance.getFoodNameById(FK_FoodID ?? 0);
                    }
                    else
                    {
                        _DEntry = Model.Instance.getIngredientNameById(FK_IngredientID ?? 0);
                    }
                }

                return _DEntry;
            }
        }
        public string DQuantity { get; set; }
    }
}

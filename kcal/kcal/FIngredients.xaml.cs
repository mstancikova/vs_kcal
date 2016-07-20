using kcal.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class FIngredients : ContentPage
    {
        public FIngredients()
        {
            InitializeComponent();
            FoodIngredients.ItemsSource = Model.getInstance().FoodIngredients;
            btn_addfoodingredient.Clicked += Btn_addfoodingredient_Clicked;
        }

        private void Btn_addfoodingredient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FI_edit());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class D_edit : ContentPage
    {
        public D_edit()
        {
            InitializeComponent();
            btn_choose_ingredient.Clicked += Btn_choose_ingredient_Clicked;
            btn_choose_food.Clicked += Btn_choose_food_Clicked;
        }

        private void Btn_choose_food_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Foods());
        }

        private void Btn_choose_ingredient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ingredients());
        }
    }
}

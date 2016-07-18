using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kcal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            try {
                InitializeComponent();
                btn_diario.Clicked += Btn_diario_Clicked;
                btn_ingredients.Clicked += Btn_ingredients_Clicked;
                btn_foods.Clicked += Btn_foods_Clicked;

            }catch(Exception e)
            {
                int i = 1;
            }

        }

        private void Btn_foods_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Foods());
        }

        private void Btn_ingredients_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ingredients());
        }

        private void Btn_diario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Diario());
        }
    }
}

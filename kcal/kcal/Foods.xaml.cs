using kcal.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class Foods : ContentPage
    {
        public Foods()
        {
            InitializeComponent();
            FoodsList.ItemsSource = Model.getInstance().Foods;
            btn_addfood.Clicked += Btn_addfood_Clicked;
        }

        private void Btn_addfood_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new F_edit());
        }
    }
}

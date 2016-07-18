using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class Ingredients : ContentPage
    {
        public Ingredients()
        {
            InitializeComponent();

            btn_addingredient.Clicked += Btn_addingredient_Clicked;

        }

        private void Btn_addingredient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new I_edit());
        }
    }
}

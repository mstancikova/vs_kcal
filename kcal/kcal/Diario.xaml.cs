using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class Diario : ContentPage
    {
        public Diario()
        {
            InitializeComponent();
            btn_adddiary.Clicked += Btn_adddiary_Clicked;
        }

        private void Btn_adddiary_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new D_edit());
        }


    }
}

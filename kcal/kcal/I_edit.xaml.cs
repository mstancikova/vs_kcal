using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class I_edit : ContentPage
    {
        public I_edit()
        {
            InitializeComponent();
            btn_choose_categories.Clicked += Btn_choose_categories_Clicked;
        }

        private void Btn_choose_categories_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Categories());
        }
    }
}

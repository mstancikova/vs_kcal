﻿using kcal.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kcal
{
    public partial class Categories : ContentPage
    {
        public Categories()
        {
            InitializeComponent();
            CategoriesList.ItemsSource = Model.getInstance().Categories;
            btn_addcategory.Clicked += Btn_addcategory_Clicked;
        }

        private void Btn_addcategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new C_edit());
        }
    }
}
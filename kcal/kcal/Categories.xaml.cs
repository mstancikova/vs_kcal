﻿using kcal.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            CategoriesList.ItemsSource = Model.Instance.Categories;
            btn_addcategory.Clicked += Btn_addcategory_Clicked;
            CategoriesList.ItemSelected += CategoriesList_ItemSelected;     /* SELECTED ITEM */
            CategoriesList.ItemTapped += CategoriesList_ItemTapped;         /* TAPPED ITEM */
        }
        /* TAPPED ITEM */
        async void CategoriesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            textLabel.Text = (e.Item as db.Category).CName;

            var action = await DisplayActionSheet("Actions for:" + textLabel.Text, "Cancel", null, "Select", "Edit", "Delete");
            if (action == "Select")
            {
                Debug.WriteLine("Select Action: " + action);
            }else if (action == "Edit")
            {
                Debug.WriteLine("Edit Action: " + action);
            }else if(action == "Delete")
            {
                Debug.WriteLine("Delete Action: " + action);
            }

        }
        /* SELECTED ITEM */
        private void CategoriesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CategoriesList.SelectedItem = null;
        }
        /* ADD NEW CATEGORY */
        private void Btn_addcategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new C_edit());
        }


        /* CONTEXTUAL MENU ---------- */
        /* EDIT BUTTON */
        public void cm_btn_Edit(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Category).CName;
            Model.Instance.CurentCategory = (m.CommandParameter as db.Category);
            Navigation.PushAsync(new C_edit());
        }
        /* DELETE BUTTON */
        public void cm_btn_Delete(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Category).CName;
        }

    }
}

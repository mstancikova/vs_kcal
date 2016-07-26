using kcal.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            FoodsList.ItemsSource = Model.Instance.Foods;
            btn_addfood.Clicked += Btn_addfood_Clicked;
            FoodsList.ItemSelected += FoodsList_ItemSelected;   /* SELECTED ITEM */
            FoodsList.ItemTapped += FoodsList_ItemTapped;       /* TAPPED ITEM */ 
        }
        /* TAPPED ITEM */
        async void FoodsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            textLabel.Text = (e.Item as db.Foods).FName;

            var action = await DisplayActionSheet("Actions for: " + textLabel.Text, "Cancel", null, "Select", "Add Ingredients", "Edit", "Delete");
            if (action == "Select")
            {
                Debug.WriteLine("Select Action: " + action);
            }
            else if (action == "Add Ingredients")
            {
                Debug.WriteLine("Add Ingredients Action: " + action);
            }
            else if (action == "Edit")
            {
                Debug.WriteLine("Edit Action: " + action);
            }
            else if (action == "Delete")
            {
                Debug.WriteLine("Delete Action: " + action);
            }
        }
        /* SELECTED ITEM */
        private void FoodsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FoodsList.SelectedItem = null;
        }
        /* ADD NEW FOOD */
        private void Btn_addfood_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new F_edit());
        }

        /* CONTEXTUAL MENU ---------- */
        /* EDIT BUTTON */
        public void cm_btn_Edit(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).FName;
            Model.Instance.CurentFood = (m.CommandParameter as db.Foods);
            Navigation.PushAsync(new F_edit());
        }
        /* EDIT INGREDIENS */
        public void cm_btn_EditIngredients(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).FName;
            Model.Instance.CurentFood = (m.CommandParameter as db.Foods);
            Navigation.PushAsync(new FIngredients()); /* here need to send ID of food for show list of ingredients */
        }
        /* DELETE BUTTON */
        public void cm_btn_Delete(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).FName;
        }
    }
}

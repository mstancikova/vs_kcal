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
            textLabel.Text = (e.Item as db.Foods).Name;

            var action = await DisplayActionSheet("Actions for: " + textLabel.Text, "Cancel", null, "Select", "Edit food name", "Edit food ingredients", "Delete");

            switch (action)
            {
                case "Select":
                    Debug.WriteLine("Select Action: " + action);
                    break;
                case "Edit food name":
                    Model.Instance.CurentFood = (e.Item as db.Foods);
                    await Navigation.PushAsync(new F_edit());
                    break;
                case "Edit food ingredients":
                    Model.Instance.CurentFood = (e.Item as db.Foods);
                    await Navigation.PushAsync(new FIngredients());
                    break;
                case "Delete":
                    var answer = await DisplayAlert("Are you sure you want to delete this food?", (e.Item as db.Foods).Name, "Yes", "No");
                    switch (answer)
                    {
                        case true:
                            Debug.WriteLine("Select Action: " + answer);
                            break;
                        case false:
                            Debug.WriteLine("Select Action: " + answer);
                            break;
                    }
                    break;
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
        /*public void cm_btn_Edit(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).Name;
            Model.Instance.CurentFood = (m.CommandParameter as db.Foods);
            Navigation.PushAsync(new F_edit());
        }*/
        /* EDIT INGREDIENS */
       /* public void cm_btn_EditIngredients(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).Name;
            Model.Instance.CurentFood = (m.CommandParameter as db.Foods);
            Navigation.PushAsync(new FIngredients());
        }*/
        /* DELETE BUTTON */
        /*public void cm_btn_Delete(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Foods).Name;
        }*/
    }
}

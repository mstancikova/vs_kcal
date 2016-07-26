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
    public partial class FIngredients : ContentPage
    {
        public FIngredients()
        {
            InitializeComponent();
            FoodIngredients.ItemsSource = Model.Instance.FoodIngredients;
            btn_addfoodingredient.Clicked += Btn_addfoodingredient_Clicked;
            FoodIngredients.ItemSelected += FoodIngredients_ItemSelected;   /* SELECTED ITEM */
            FoodIngredients.ItemTapped += FoodIngredients_ItemTapped;       /* TAPPED ITEM */
        }
        /* TAPPED ITEM */
        async void FoodIngredients_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            textLabel.Text = String.Format("ID: {0}", (e.Item as db.FIngredients).FK_IngredientID);

            var action = await DisplayActionSheet("Actions for: "+textLabel.Text, "Cancel", null, "Select", "Edit", "Delete");
            if (action == "Select")
            {
                Debug.WriteLine("Select Action: " + action);
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
        private void FoodIngredients_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FoodIngredients.SelectedItem = null;
        }
        /* ADD INGREDIENT BUTTON */
        private void Btn_addfoodingredient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FI_edit());
        }

        /* CONTEXTUAL MENU ---------- */
        /* EDIT BUTTON */
        public void cm_btn_Edit(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = String.Format("ID: {0}", (m.CommandParameter as db.FIngredients).FK_IngredientID);
            Model.Instance.CurentFIngredient = (m.CommandParameter as db.FIngredients);
            Navigation.PushAsync(new FI_edit());
        }
        /* DELETE BUTTON */
        public void cm_btn_Delete(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = String.Format("ID: {0}", (m.CommandParameter as db.FIngredients).FK_IngredientID);
        }
    }
}

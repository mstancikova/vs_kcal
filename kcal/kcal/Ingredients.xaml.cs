using kcal.db;
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
            IngredientsList.ItemsSource = Model.Instance.Ingredients;
            btn_addingredient.Clicked += Btn_addingredient_Clicked;
            IngredientsList.ItemSelected += IngredientsList_ItemSelected;   /* SELECTED ITEM */
            IngredientsList.ItemTapped += IngredientsList_ItemTapped;       /* TAPPED ITEM */
        }
        /* TAPPED ITEM */
        private void IngredientsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            textLabel.Text = (e.Item as db.Ingredients).IName;
        }
        /* SELECTED ITEM */
        private void IngredientsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IngredientsList.SelectedItem = null;
        }
        /* ADD NEW INGREDIENT */
        private void Btn_addingredient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new I_edit());
        }

        /* CONTEXTUAL MENU ---------- */
        /* EDIT BUTTON */
        public void cm_btn_Edit(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Ingredients).IName;
            Model.Instance.CurentIngredient = (m.CommandParameter as db.Ingredients);
            Navigation.PushAsync(new I_edit());
        }
        /* DELETE BUTTON */
        public void cm_btn_Delete(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            textLabelforContext.Text = (m.CommandParameter as db.Ingredients).IName;
        }
    }
}

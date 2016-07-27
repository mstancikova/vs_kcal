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
    public partial class Diary : ContentPage
    {
        public Diary()
        {
            InitializeComponent();
            DiaryList.ItemsSource = Model.Instance.Diary;
            btn_adddiary.Clicked += Btn_adddiary_Clicked;
            DiaryList.ItemSelected += DiaryList_ItemSelected;     /* SELECTED ITEM */
            DiaryList.ItemTapped += DiaryList_ItemTapped;         /* TAPPED ITEM */
        }


        /* TAPPED ITEM */
        async void DiaryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            textLabel.Text = (e.Item as db.Diary).DEntry;
            
            var action = await DisplayActionSheet("Actions for:" + textLabel.Text, "Cancel", null, "Select", "Edit", "Delete");

            switch (action)
            {
                case "Select":
                    Debug.WriteLine("Select Action: " + action);
                    break;
                case "Edit":
                    Model.Instance.CurentDiaryEntry = (e.Item as db.Diary);
                    await Navigation.PushAsync(new D_edit());
                    break;
                case "Delete":
                    var answer = await DisplayAlert("Are you sure you want to delete this diary entry?", (e.Item as db.Diary).DEntry, "Yes", "No");
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
        private void DiaryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DiaryList.SelectedItem = null;
        }
        /* ADD NEW DIARY ENTRY */
        private void Btn_adddiary_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new D_edit());
        }

    }
}

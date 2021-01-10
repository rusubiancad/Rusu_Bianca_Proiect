using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rusu_Bianca_Proiect.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rusu_Bianca_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramareEntryPage : ContentPage
    {
        public ProgramareEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProgramareAsync();
        }
        async void OnProgramareAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgramarePage
            {
                BindingContext = new ProgramareExamen()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ProgramarePage
                {
                    BindingContext = e.SelectedItem as ProgramareExamen
                });
            }
        }
    }
}
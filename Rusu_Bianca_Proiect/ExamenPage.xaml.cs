using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rusu_Bianca_Proiect.Data;
using Rusu_Bianca_Proiect.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rusu_Bianca_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamenPage : ContentPage
    {
        ProgramareExamen p;
        public ExamenPage(ProgramareExamen programare)
        {
            InitializeComponent();
            p = programare;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var examen = (Examen)BindingContext;
            await App.Database.SaveExamenAsync(examen);
            listView.ItemsSource = await App.Database.GetExameneAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var examen = (Examen)BindingContext;
            await App.Database.DeleteExamenAsync(examen);
            listView.ItemsSource = await App.Database.GetExameneAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetExameneAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Examen ex;
            if (e.SelectedItem != null)
            {
                ex = e.SelectedItem as Examen;
                var le = new ListExamen()
                {
                    ProgramareExamenID = p.ID,
                    ExamenID = ex.ID
                };
                await App.Database.SaveListExamenAsync(le);
                ex.ListExamene = new List<ListExamen> { le };

                await Navigation.PopAsync();
            }
        }
    }
}
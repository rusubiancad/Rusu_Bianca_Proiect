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
    public partial class ProgramarePage : ContentPage
    {
        public ProgramarePage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (ProgramareExamen)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveProgramareAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (ProgramareExamen)BindingContext;
            await App.Database.DeleteProgramareAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExamenPage((ProgramareExamen)
           this.BindingContext)
            {
                BindingContext = new Examen()
            });

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var progex = (ProgramareExamen)BindingContext;

            listView.ItemsSource = await App.Database.GetListExameneAsync(progex.ID);
        }
    }
}
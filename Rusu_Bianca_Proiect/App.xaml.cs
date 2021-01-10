using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rusu_Bianca_Proiect.Data;
using System.IO;

namespace Rusu_Bianca_Proiect
{
    public partial class App : Application
    {

        static BDProgramari database;
        public static BDProgramari Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   BDProgramari(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Programare.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProgramareEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

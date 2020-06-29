using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RunningApp.Services;
using RunningApp.Views;
using RunningApp.Data;



namespace RunningApp
{
    public partial class App : Application
    {

        static HistoricoDatabase database;

        public static HistoricoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new HistoricoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "historico.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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

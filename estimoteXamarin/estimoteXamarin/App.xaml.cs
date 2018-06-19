using estimoteXamarin.Models;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace estimoteXamarin
{
    public partial class App : Application
    {
        protected SQLiteAsyncConnection conn;

        public App(string dbPath)
        {
            Helpers.Settings.DbPath = dbPath;
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Implementation>();
            conn.CreateTableAsync<ProximityZone>();
            conn.CreateTableAsync<Sector>();
            conn.CreateTableAsync<Beacon>();

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

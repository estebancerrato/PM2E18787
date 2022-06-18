using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2Examen.Views;

namespace PM2Examen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new listarsitios());
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

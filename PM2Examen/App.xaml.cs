using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2Examen.Views;
using PM2Examen.Controllers;
using PM2Examen.Models;

namespace PM2Examen
{
    public partial class App : Application
    {
      
        
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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

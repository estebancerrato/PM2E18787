using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2Examen.Views;

namespace PM2Examen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listarsitios : ContentPage
    {
        public listarsitios()
        {
            InitializeComponent();
        }

        private void toolmenu_Clicked(object sender, EventArgs e)
        {

        }

        private void liestasistios_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void btneliminacasa_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnvermapa_Clicked(object sender, EventArgs e)
        {
            //Sintaxis para dirigirnos a otra pantalla
            await Navigation.PushAsync(new ver_mapa());
        }
    }
  }

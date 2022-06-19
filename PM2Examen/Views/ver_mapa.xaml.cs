using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace PM2Examen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ver_mapa : ContentPage
    {
        String maplatitud, maplongitud, mapdescripcion;
        public ver_mapa(String latitud, String longitud, String descripcion)
        {
            InitializeComponent();
            maplatitud = latitud;
            maplongitud = longitud;
            mapdescripcion = descripcion;

            
        }

        private void toolmenu_Clicked(object sender, EventArgs e)
        {

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Pin ubicacion = new Pin();
            ubicacion.Label = mapdescripcion.ToString();
            ubicacion.Position = new Position( Double.Parse(maplongitud), Double.Parse(maplatitud));
            mapa.Pins.Add(ubicacion);



        }

    }
}
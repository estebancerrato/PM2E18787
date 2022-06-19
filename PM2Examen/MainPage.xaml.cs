using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using System.IO;
using PM2Examen.Views;
using PM2Examen.Models;
using PM2Examen.Controllers;

namespace PM2Examen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            obtenerLatitudLongitud();
        }

        public async void obtenerLatitudLongitud()
        {
            try
            {
                var georequest = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

                var tokendecancelacion = new System.Threading.CancellationTokenSource();

                var localizacion = await Geolocation.GetLocationAsync(georequest, tokendecancelacion.Token);


                if (localizacion != null)
                {
                    txtlatitud.Text = localizacion.Latitude.ToString();
                    txtlongitud.Text = localizacion.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Advertencia", "Este dispositivo no soporta GPS"+ fnsEx, "Ok");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Advertencia", "Error de Dispositivo "+ fneEx, "Ok");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Advertencia", "Sin Permisos de Geolocalizacion" + pEx, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Advertencia", "Sin Ubicacion " + ex, "Ok");
            }
        }

        byte[] imageToSave;
        private async void AddImg(object sender, EventArgs e)
        {
            try
            {  

                var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "PhotoApp",
                    Name = DateTime.Now.ToString() + "_foto.jpg",
                    SaveToAlbum = true
                });

                await DisplayAlert("Ubicacion de la foto: ", takepic.Path, "Aceptar");

                if (takepic != null)
                {
                    imageToSave = null;
                    MemoryStream memoryStream = new MemoryStream();

                    takepic.GetStream().CopyTo(memoryStream);
                    imageToSave = memoryStream.ToArray();

                    img.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });
                }
                obtenerLatitudLongitud();
                txtdescripcion.Focus();//le pasamos el puntero a la descripcion
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Se ha generado el siguiente error al agregar la imagen "+ex, "Aceptar");
            }
        }

        private async void btnlistar_Clicked(object sender, EventArgs e)
        {
            //Sintaxis para dirigirnos a otra pantalla
            await Navigation.PushAsync(new listarsitios());
        }

        private void btnsalir_Clicked(object sender, EventArgs e)
        {
            //mandamos un sentesia para que mate el proseso 
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private async void btnagregars_Clicked(object sender, EventArgs e)
        {
            var sitio = new sitios
            {
                imagen = imageToSave,
                longitud = Int32.Parse(txtlatitud.Text),
                latitud = Int32.Parse(txtlongitud.Text),
                descripcion = txtdescripcion.Text
            };
            //var resultado = await App.
        }
    }
}

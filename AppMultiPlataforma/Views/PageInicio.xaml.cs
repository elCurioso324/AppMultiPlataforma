using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMultiPlataforma
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInicio : ContentPage
    {
        private static string address = "";
        public string Address { get => address; set => address = value; }
        public PageInicio()
        {
            InitializeComponent();
            Super();
        }


        public void Super()
        {
            Datos dat = new Datos();
            if (!string.IsNullOrEmpty(dat.SuperUsuario.EmailAddress))
            {
                btnRegistrarse.IsVisible = false;
            }
        }

        /// <summary>
        /// El siguiente método permite validar que el usuario exista en el sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Segun el tipo de usuario que sea asi se manejara la forma de entrar a la app
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            PageRegistro user = new PageRegistro();
            Datos dat = new Datos();
            int i = 0;
            try
            {
                if (!string.IsNullOrEmpty(texClave.Text) && !string.IsNullOrEmpty(texCorreo.Text))
                {
                    address = texCorreo.Text;//permitira saber quien se conecta 
                    if (texCorreo.Text == dat.SuperUsuario.EmailAddress && PageRegistro.Encryptar(texClave.Text) == dat.SuperUsuario.Password)
                    {
                        Navigation.PushAsync(new PageRegistro());
                    }
                    else
                    {
                        while (i < user.UserList.Length && user.UserList[i] != null)
                        {
                            if (texCorreo.Text == user.UserList[i].EmailAddress && PageRegistro.Encryptar(texClave.Text) == user.UserList[i].Password)
                            {
                                Navigation.PushAsync(new PageCursos());
                            }
                            else if (dat.UserList[i+1] == null)
                            {
                                App.Current.MainPage.DisplayAlert("Advertencia", "No existe el usuario", "Aceptar");
                                break;
                            }
                            i++;
                        }
                    }
                    if (string.IsNullOrEmpty(dat.SuperUsuario.EmailAddress))
                        App.Current.MainPage.DisplayAlert("Advertencia", "No existen usuarios registrados", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Evento que manipula la navegacion de la pagina actual a la pagina de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageRegistro());
        }
    }
}
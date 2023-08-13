using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;
using System.Text;

namespace AppMultiPlataforma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRegistro : ContentPage
	{
        private bool entrar;
        private static string address = "";
        private static ClassUser[] userList = new ClassUser[50];
        private static Datos dat = new Datos();

        internal ClassUser[] UserList { get => userList; set => userList = value; }

        public string Address { get => address; set => address = value; }
        public Datos Dat { get => dat; set => dat = value; }

        public PageRegistro ()
		{
			InitializeComponent ();
            btnseguir.IsVisible = false;
            Super();
        }
        
        public void Super()
        {
            Datos dat = new Datos();
            if (string.IsNullOrEmpty(dat.SuperUsuario.EmailAddress))
            {
                lblTitulo.Text = "Registrar Encargado";
            }
            else
            {
                lblxxx.Text = "Ingresar los datos";
                lblTitulo.Text = "Registrar estudiante";
            }
        }
        /// <summary>
        /// Crea el encriptado y lo devuelve mediante el retorno
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encryptar(string clave)
        {
            try
            {
                using (SHA256 cifrado = SHA256.Create())
                {
                    byte[] encriptado = cifrado.ComputeHash(Encoding.UTF8.GetBytes(clave));

                    StringBuilder dev_Cifrado = new StringBuilder();
                    foreach (byte b in encriptado)
                    {   // convierte el Byte a un string hexadecimal
                        dev_Cifrado.Append(b.ToString("x2"));
                    }
                    return dev_Cifrado.ToString();
                }
            }catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Alerta", ex.ToString(), "Ok");
                return "false";
            }
        }
        /// <summary>
        /// Método encargado de validar la contraceña que no se encuentre vacido
        /// </summary>
        /// <returns>El valor ingresado de lo contrario lo devuelve vacido</returns>
        public string Password()
        {
            try
            {
                if (texPassword1.Text.Length < 4)
                {
                    texPassword1.BackgroundColor = Color.LightCoral;
                    entrar = false;
                }
                else if (string.IsNullOrEmpty(texPassword1.Text))
                {
                    texPassword1.Placeholder = "Ingrese un valor";
                    texPassword1.PlaceholderColor = Color.Red;
                    texPassword1.BackgroundColor = Color.LightCoral;
                    entrar = false;
                }
            } catch (Exception e){
                App.Current.MainPage.DisplayAlert("Alerta", e.ToString(), "Ok");
            }
            return texPassword1.Text;
        }
        /// <summary>
        /// Método que valida la igualdad de la clave, devolviendo un valor booleano de la igualdad
        /// </summary>
        public bool ValPassword2()
        {
            try
            {
                if (texPassword2.Text == texPassword1.Text)
                {
                    texPassword1.BackgroundColor = Color.LightGreen;
                    texPassword2.BackgroundColor = Color.LightGreen;
                    return true;
                }
                else
                {
                    texPassword2.BackgroundColor = Color.LightCoral;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Alerta", ex.ToString(), "Ok");
            }     
            return false;       
        }        
        /// <summary>
        /// Método encargado de validar si el espacio se encantra vacido cambiando el valor booleano de la variable "entrar"
        /// A su vez esta variable "entrar" impedira que los datos se almacenen hasta haber llenado todos los campos 
        /// </summary>
        /// <param name="x">Recibe por parametro la variable que contiene el texto ingresado</param>
        /// <returns>Devuelve el valor dentro de la variable en tipo string</returns>
        public string Validacion(Entry x)
        {
            try
            {
                if (string.IsNullOrEmpty(x.Text))
                {
                    x.Placeholder = "Ingrese un valor";
                    x.PlaceholderColor = Color.Red;
                    entrar = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Alerta", ex.ToString(), "Ok");
            }
            return x.Text;
        }
        /// <summary>
        /// Método encargado de validar el email que no se encuentre vacido y que no este registrado para otro usuario
        /// </summary>
        /// <returns>Devuelve el valor ingresado, de lo contrario lo devuelve vacido</returns>
        public string correo()
        {
            Datos dat = new Datos();
            int i = 0;
            try
            {
                if (string.IsNullOrEmpty(texAddress.Text))
                {
                    texAddress.Placeholder = "ingrese un valor";
                    texAddress.PlaceholderColor = Color.Red;
                    entrar = false;
                    return texAddress.Text;//si la variable esta vacia lo saca del método al instante
                }
                while (i < userList.Length && userList[i] != null)
                { //Permite verificar que no exista otro correo identico en los datos.
                    if (texAddress.Text == userList[i].EmailAddress)
                    {
                        texAddress.Placeholder = "Ya esta en uso";
                        texAddress.PlaceholderColor = Color.Red;
                        entrar = false;
                        break;
                    }
                    else if (userList[i] == null)
                    {
                        texAddress.BackgroundColor = Color.LightGreen;
                        break;
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Alerta", e.ToString(), "Ok");
            }
            return texAddress.Text;
        }

        /// <summary>
        /// Evendo del botón volver que permite regresar al usuario a la pagina de inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        
        private void btnseguir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCursos());
        }
        /// <summary>
        /// Evendo del botón registrar usuario que permite generar el gardado de los datos del usuario a la hora de precionarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                ClassUser user = new ClassUser();
                entrar = true;
                user.Name = Validacion(texName); 
                user.LastName1 = Validacion(texApellido1); 
                user.LastName2 = Validacion(texApellido2); 
                user.IdUser = Validacion(texID); 
                user.BornDate = dateBorn.Date;
                user.EmailAddress = correo();
                user.PhoneNumber = Validacion(texCell);
                user.Password = Encryptar(Password());
                //Si la variable booleana "entrar" se mantiene en true y las confirmación de clave coincide se permite almacenar la información
                if (entrar && ValPassword2() && dat.SuperUsuario.EmailAddress.Length > 0)
                {
                    while (i < userList.Length)
                    {
                        if (userList[i] == null) 
                        {
                            userList[i] = user;
                            dat.UserList = userList;
                            address = user.EmailAddress;
                            pngExito.IsVisible = true;
                            lblMMS.IsVisible = true;
                            btnseguir.IsVisible = true;
                            btnRegistrarse.IsVisible = false;
                            await App.Current.MainPage.DisplayAlert("Confirmación", "El estudiante se a agregado correctamente", "Aceptar");
                            break;
                        }
                        i++;
                    }
                }
                else if(entrar && ValPassword2())
                {
                    btnRegistrarse.IsVisible = false;
                    dat.SuperUsuario = user;
                    pngExito.IsVisible = true;
                    lblMMS.IsVisible = true;
                    await App.Current.MainPage.DisplayAlert("Confirmación", "El Usuario se a agregado correctamente", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.ToString(), "Ok");
                return;
            }
        }

    }
}
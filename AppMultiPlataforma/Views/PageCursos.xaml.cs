using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMultiPlataforma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCursos : ContentPage
    {
        private static ClassUser User = new ClassUser();
        private static int contador = 0;

        internal ClassUser User_1 { get => User; set => User = value; }
        public int Contador { get => contador; set => contador = value; }

        public PageCursos()
        {
            InitializeComponent();
            Recopilar();
        }
        /// <summary>
        /// El siguiente metodo rescata el correo ingresado en el inisio de sesión
        /// </summary>
        /// Esta información permite ubicar los datos del usuario para su manipulación.
        private void Recopilar()
        {
            PageRegistro inicio = new PageRegistro();
            Datos datos = new Datos();
            try
            {
                string tex;
                tex = inicio.Address;
                while (true)
                {
                    if(tex == datos.UserList[contador].EmailAddress)
                    {
                        User = datos.UserList[contador];
                    }
                    contador++;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageDatos());
        }
        /// <summary>
        /// Permite validar las entradas de datos por separado para que no se guarden datos vacios
        /// </summary>
        /// <param name="tex">El parameto corresponde al Entry que desea validar</param>
        /// <returns>Devuelve una variable tipo string del dato recibido</returns>
        public string Validar(Entry tex)
        {
            if (string.IsNullOrEmpty(tex.Text))
            {
                tex.Placeholder = "Ingrese un valor";
                tex.PlaceholderColor = Color.Red;
            }
            return tex.Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            Curso curso = new Curso();
            int i = 0;
            try
            {//!string.IsNullOrEmpty(texCodigo.Text) && !string.IsNullOrEmpty(texCurso.Text)
                if (!string.IsNullOrEmpty(Validar(texCurso)) && !string.IsNullOrEmpty(Validar(texCodigo)))
                {
                    while (i < 3)
                    {
                        if (User.Cursos[i] == null)
                        {
                            App.Current.MainPage.DisplayAlert("Confirmación", "El curso se asigno correctamente", "Ok");
                            curso.Codigo = texCodigo.Text;
                            curso.Asignatura = texCurso.Text;
                            User.Cursos[i] = curso;
                            datos.UserList[contador].Cursos[i] = curso;
                            break;
                        }
                        else if (i == 2)
                        {   //Accion de error cuando todos los campos esten llenos
                            this.texCodigo.TextColor = Color.Red;
                            this.texCurso.TextColor = Color.Red;
                            this.lblMMS.Text = "As llegado al limite de asignaturas.";
                            this.pngError.IsVisible = true;
                        }
                        i++;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
    }
}
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMultiPlataforma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDatos : ContentPage
    {
        public PageDatos()
        {
            InitializeComponent();
            Cargar();
        }
        /// <summary>
        /// El siguiente método se encarga de cargar los datos al inicializar la pagina
        /// </summary>
        public void Cargar()
        {
            PageRegistro dat = new PageRegistro();
            PageInicio pageInicio = new PageInicio();
            Datos user = new Datos();
            int i = 0;
            try
            {
                while (dat.UserList[i] != null)
                {
                    if(pageInicio.Address == dat.UserList[i].EmailAddress && pageInicio.Address != user.SuperUsuario.EmailAddress)
                    {
                        btnNuevo.IsVisible = false;
                        precentar(i);
                    }
                    else if (pageInicio.Address == user.SuperUsuario.EmailAddress && dat.UserList[i+1] == null)
                    {
                        precentar(i);
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return;
            }           
        }
        public void precentar(int i)
        {
            Datos dat = new Datos();
            try
            {
                lblID.Text = dat.UserList[i].IdUser;
                lblName.Text = dat.UserList[i].Name;
                lblApell_1.Text = dat.UserList[i].LastName1;
                lblApell_2.Text = dat.UserList[i].LastName2;
                lblCell.Text = dat.UserList[i].PhoneNumber;
                lblEmail.Text = dat.UserList[i].EmailAddress;
                lblFecha.Text = dat.UserList[i].BornDate.ToString();
                lblClave.Text = dat.UserList[i].Password;
                //En caso de que los siguientes datos no existan se activa el catch ignorando los datos
                lblCurso_1.Text = dat.UserList[i].Cursos[0].Codigo + " " + dat.UserList[i].Cursos[0].Asignatura;
                lblCurso_2.Text = dat.UserList[i].Cursos[1].Codigo + " " + dat.UserList[i].Cursos[1].Asignatura;
                lblCurso_3.Text = dat.UserList[i].Cursos[2].Codigo + " " + dat.UserList[i].Cursos[2].Asignatura;                
            }
            catch (Exception e)
            {
                return;
                //App.Current.MainPage.DisplayAlert("Alerta", e.ToString(), "Ok");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageInicio());
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageRegistro());
        }
    }
}
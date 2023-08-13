using AppMultiPlataforma.Services;
using AppMultiPlataforma.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMultiPlataforma
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new PageInicio());
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

using AppMultiPlataforma.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMultiPlataforma.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
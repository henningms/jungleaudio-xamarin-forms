using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JungleAudio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JungleAudio.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public FavoritesViewModel ViewModel { get; set; }
        public Page1()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.RetrieveFavoritesAsync();
        }
    }
}

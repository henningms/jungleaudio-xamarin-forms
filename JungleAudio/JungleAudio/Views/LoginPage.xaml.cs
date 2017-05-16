using JungleAudio.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JungleAudio.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        bool firstTime = true;

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        /*protected override void OnAppearing()
        {
            base.OnAppearing();

            AudioWebView.Navigated += AudioWebViewOnNavigated;
      
            //AudioWebView.Source = "http://audiojungle.net/sign_in";
        }

        private void AudioWebViewOnNavigated(object sender, WebNavigatedEventArgs webNavigatedEventArgs)
        {
            if (firstTime)
            {
                firstTime = false;
            }
            else
            {
                AudioWebView.IsVisible = false;

                Navigation.PushAsync(new Page1());
            }
        }
        */
        private void Button_OnClicked(object sender, EventArgs e)
        {
            //AudioWebView.IsVisible = true;
        }
    }
}

using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if(entryUsername.Text == "admin" && entryPassword.Text == "123")
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                DisplayAlert("ERROR", "Username or password are incorrect.", "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
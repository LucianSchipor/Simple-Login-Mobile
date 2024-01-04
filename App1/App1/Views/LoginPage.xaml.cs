using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {

            string serverDatabaseName = "Mobile";
            string serverName = "192.168.0.106";
            string serverusername = "lucian";
            string serverpassword = "1234";
            string constring = $"Data Source={serverName};Initial Catalog={serverDatabaseName};User ID={serverusername};Password={serverpassword};Connect Timeout=30;";

            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string loginName = entryUsername.Text;
                    string loginPass = entryPassword.Text;
                    string queryString = "SELECT Prenume FROM Users WHERE Nume = @LoginName";

                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        // Setează parametrii pentru nume și prenume
                        cmd.Parameters.AddWithValue("@LoginName", loginName);

                        // Execută query-ul și primește rezultatul
                        string storedPassword = cmd.ExecuteScalar() as string;

                        // Verifică rezultatul
                        if (!string.IsNullOrEmpty(storedPassword) && storedPassword.Equals(loginPass))
                        {
                            DisplayAlert("OK", "Utilizator conectat cu succes.", "OK");
                        }
                        else
                        {
                            DisplayAlert("OK", "Numele de utilizator sau parola incorecte.", "OK");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.ToString(), "OK");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
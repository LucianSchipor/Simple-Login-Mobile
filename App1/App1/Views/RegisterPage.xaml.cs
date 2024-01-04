using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
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
                    string registerName = entryUsername.Text;
                    string registerPass = entryPassword.Text;
                    string queryString = "INSERT into Users (Nume, Prenume) VALUES (@Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        // Setează parametrii pentru nume și prenume
                        cmd.Parameters.AddWithValue("@Username", registerName);
                        cmd.Parameters.AddWithValue("@Password", registerPass);

                        // Execută query-ul și primește rezultatul
                        try
                        {
                            cmd.ExecuteNonQuery();
                            DisplayAlert("OK","Registered successfully","OK");
                            Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                        }
                        catch (Exception ex)
                        {
                            DisplayAlert("Error", ex.ToString(), "OK");
                        }

                        // Verifică rezultatul

                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.ToString(), "OK");
                }
            }
        }

    }
}
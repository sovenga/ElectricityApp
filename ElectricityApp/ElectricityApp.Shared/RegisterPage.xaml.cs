using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ElectricityApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        UserViewModel user = null;
        private App app = (Application.Current as App);
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            user = new UserViewModel();
            string username = txtUserName.Text;
            
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;
            if (!username.Equals("") && !password.Equals(""))
            {
                if (password.Equals(confirm))
                {
                    user.addUser(username, password);
                    messageBox("account has been created");
                }
                else
                {
                    messageBox("Passwords do not match");
                }
                txtPassword.Text = "";
                txtConfirm.Text = "";
            }
            else { messageBox("Sorry!!!!These fields cannot be left blank"); }
        }
    }
}

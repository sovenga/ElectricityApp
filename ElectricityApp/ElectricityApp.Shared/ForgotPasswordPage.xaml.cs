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
    public sealed partial class ForgotPasswordPage : Page
    {
        UserViewModel user = null;
        public ForgotPasswordPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            user = new UserViewModel();
            User userObject = user.getPassowrd(username);
            if (userObject != null)
            {
                lblPassword.Text = "Your Password Is " + userObject.PASSWORD;
                messageBox("Success!!! "+userObject.PASSWORD+" Will always be returned as long as you remember your username");
                txtUserName.Text = "";
            }else{
                messageBox("Sorry!!!Password for "+username+" cannot be found");
            }
           
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
    }
}

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
    public sealed partial class RemoveUserPage : Page
    {
        private UserViewModel user;
        public RemoveUserPage()
        {
            this.InitializeComponent();
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try { 
                string username = txtUserName.Text;
                user = new UserViewModel();
                if (user.verify(username) != null)
                {
                    user.removeUser(username);
                    messageBox("User has been removed");
                    this.Frame.Navigate(typeof(MainPage));
                }
                else {
                    messageBox("Error!!! ");
                }
            }
            catch
            {

                messageBox("Error!!! cannot find user");
            }
            txtUserName.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(WelcomePage));
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using ElectricityApp.ViewModels;
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
    public sealed partial class AddAppliancePage : Page
    {
        private ApplianceViewModel applianceViewModel;
        public AddAppliancePage()
        {
            this.InitializeComponent();
            txtNumberOfItems.Text = "1";
            txtWatts.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WelcomePage));
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
        private void btnAddAppliance_Click(object sender, RoutedEventArgs e)
        {

            try 
            { 
                applianceViewModel = new ApplianceViewModel(); 
                string name = txtApplianceName.Text;
                string strwatts = txtWatts.Text;
                string strnumber = txtNumberOfItems.Text;
                int watts = Convert.ToInt32(txtWatts.Text);
                int number = Convert.ToInt32(txtNumberOfItems.Text);
            if (!(name.Equals("")))
            {
                applianceViewModel.addAppliance(name, watts, number);
                messageBox("Appliance Has been Saved");
                this.Frame.Navigate(typeof(ViewAppliances));
            }
            else {
               messageBox("Error!!!! Please enter the name of the appliance");
            }
            }
            catch { messageBox("Error!!!! You have to enter the watts and the total number of appliance of that type"); }
        }

    }
}

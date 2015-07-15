
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
    public sealed partial class WelcomePage : Page
    {
        ApplianceViewModel appliance = null;
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddAppliancePage));
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CheckUnitsPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private void linkView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAppliances));
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
        private void linkRemoveAppliances_Click(object sender, RoutedEventArgs e)
        {
            appliance = new ApplianceViewModel();
            appliance.deleteAllAppliances();
            messageBox("All Appliances Removed");
        }

        private void linkDropTable_Click(object sender, RoutedEventArgs e)
        {
            //appliance = new ApplianceViewModel();
            //appliance.dropAppliancesTable();
            //messageBox("Table Removed");
        }

        private void linkremoveaccount_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RemoveUserPage));
        }

        private void linkLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void HyperlinkButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAppliances));
        }

        private void linkDropHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryViewModel history = new HistoryViewModel();
            history.dropHistory();
            messageBox("success");
        }
    }
}

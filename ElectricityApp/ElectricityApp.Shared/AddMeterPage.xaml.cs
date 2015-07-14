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
    public sealed partial class AddMeterPage : Page
    {
        MeterViewModel meterModel = null;
        public AddMeterPage()
        {
            this.InitializeComponent();
            meterModel = new MeterViewModel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            string meterNumber = txtMeterNumber.Text;
            string strCurrentUnits = txtCurrentUnits.Text;
            
            try 
            {
                if (!meterNumber.Equals("") && !strCurrentUnits.Equals(""))
                {
                    double currentUnits = Convert.ToDouble(txtCurrentUnits.Text);
                    meterModel.addMeterBox(meterNumber, currentUnits);
                    messageBox("Meter Added Successfully");
                    this.Frame.Navigate(typeof(ViewAppliances));
                }
                else
                {
                    messageBox("This fields cannot be left blank!!!!");
                }
            }
            catch(Exception ex)
            {
                messageBox(ex.Message+" or cant add ths meter box");
            }
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WelcomePage));
        }

        private void linkRemoveMeters_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                meterModel.removeMeters();
                messageBox("You have deleted your meter box");
            }
            catch
            {
                messageBox("Error ocuured while deleting");
            }
           

        }
    }
}

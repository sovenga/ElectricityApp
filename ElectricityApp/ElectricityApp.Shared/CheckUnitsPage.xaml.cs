
using ElectricityApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class CheckUnitsPage : Page
    {
        AppliancesViewModel appliance = null;
        ObservableCollection<ApplianceViewModel> appliances = null;
        private ElectricityApp.App app = (Application.Current as App);
        string[] names = null;
        int[] watts = null;
        int[] number = null;
        int[] hours = null;
        int[] IDS = null;
        int count = 0;
        int totalWatts = 0;
        int totalNumber = 0;
        double UNITS = 0;
        int totalHours = 0;
        double usedUnits = 0.0;
        int TotalUnits = 0;
        int ids = 0;
        public CheckUnitsPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //getting input text fields
            string strIronHours = txtHoursIron.Text; 
            string strKettleHours = txtHoursKettle.Text;
            string strFridge = txtHoursFridge.Text;

            //Converting input text fields to Integer

            int ironHours = Convert.ToInt32(strIronHours);
            int kettleHours = Convert.ToInt32(strKettleHours);
            int fridgeHours = Convert.ToInt32(strFridge);

            double allHours = ironHours + kettleHours + fridgeHours;
            usedUnits = (totalWatts/1000) + (totalNumber * allHours);
            UNITS = TotalUnits;
            UNITS += - usedUnits; 
            txtRemainingUnits.Text = UNITS + "";
            

            messageBox("Your Total Remaining Units: "+totalWatts +" Units in your meter box");
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            appliance = new AppliancesViewModel(); 
            appliances = appliance.getAllAppliances();
            txtTotalUnits.Text = "0";
            String totUnits = txtTotalUnits.Text;
            TotalUnits = Convert.ToInt32(totUnits);

            
           
            try
            {
                
                if (appliances != null)
                {
                    names = new string[appliances.Count];
                    watts = new int[appliances.Count];
                    number = new int[appliances.Count];
                    hours = new int[appliances.Count];
                    IDS = new int[appliances.Count];
                    foreach (var a in appliances)
                    {
                        IDS[count] = a.ID;
                        names[count] = a.APPLIANCE_NAME;
                        watts[count] = a.WATTS;
                        number[count] = a.NUMBER_OF_ITEMS;

                        totalWatts += watts[count];
                        totalNumber += number[count];
                        totalHours += hours[count];
                        count++;
                    }
                    ckIron.Content = IDS[0];
                    ckKettle.Content = IDS[1];
                    ckFridge.Content = IDS[2];
                    ckTelevision.Content = IDS[3];
                    ckRadio.Content = IDS[4];
                    ckMicrowave.Content = IDS[5];
                    ckToast.Content = IDS[6];
                    ckDeskTop.Content = IDS[7];

                    lblIron.Text = names[0]; txtWattsIron.Text = watts[0] + ""; txtNumberIrons.Text = number[0] + ""; txtHoursIron.Text = 0 + "";
                    lblKettle.Text = names[1]; txtWattsKettle.Text = watts[1] + ""; txtNumberKettle.Text = number[1] + ""; txtHoursKettle.Text = 0 + "";
                    lblFridge.Text = names[2]; txtWattsFridge.Text = watts[2] + ""; txtNumberFridge.Text = number[2] + ""; txtHoursFridge.Text = 0 + "";
                    lblTv.Text = names[3]; txtWattsTV.Text = watts[3] + ""; txtNumberTV.Text = number[3] + ""; txtHoursTV.Text = 0 + "";
                    //lblTv.Text = names[4]; txtWattsTV.Text = watts[3] + ""; txtNumberTV.Text = number[3] + ""; txtHoursTV.Text = 0 + "";
                    lblRadio.Text = names[4]; txtWattsRadio.Text = watts[4] + ""; txtNumberRadio.Text = number[4] + ""; txtHoursRadio.Text = 0 + "";
                    lblMicrowave.Text = names[5]; txtWattsMicrowave.Text = watts[5] + ""; txtNumberMicrowave.Text = number[5] + ""; txtHoursMicrowave.Text = 0 + "";
                    lblToast.Text = names[6]; txtWattsToast.Text = watts[6] + ""; txtNumberToast.Text = number[6] + ""; txtHoursToast.Text = 0 + "";
                    lblDeskTop.Text = names[7]; txtWattsDesktop.Text = watts[7] + ""; txtNumberDesktop.Text = number[7] + ""; txtHoursDesktop.Text = 0 + "";
                }
                else { messageBox("no data in the table"); }
            }
            catch (Exception ex)
            {
                messageBox("error "+ex.Message);
            }
          
            base.OnNavigatedTo(e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(WelcomePage));
        }

    }
}

using ElectricityApp.model;
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
    public sealed partial class ViewAppliances : Page
    {
        List<Appliance> listAppliances = null;
        AppliancesViewModel appliancesModel = null;
        ObservableCollection<ApplianceViewModel> appliances = null;
        TextBox watts, hours, number;
        TextBox[] wats, hour, num;
        bool isPressed = false;
        
        double total_watts = 0.0;
        int tota_number = 0;
        int total_hours = 0;
        double Kilo_Watts = 0.0;
        int total_numbers_appliance1 = 0, total_numbers_appliance2 = 0, total_numbers_appliance3 = 0, total_numbers_appliance4 = 0, total_numbers_appliance5 = 0;
        int total_hours_appliance1 = 0, total_hours_appliance2 = 0, total_hours_appliance3 = 0, total_hours_appliance4 = 0, total_hours_appliance5 = 0;

        public ViewAppliances()
        {
            this.InitializeComponent();
            txtCurrentUnits.Text = "0";
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //listAppliances = model.getAllAppliances();
            appliancesModel = new AppliancesViewModel();
            try 
            {
                appliances = appliancesModel.getAllAppliances();
                if (appliances != null)
                {
                    foreach (var ap in appliances)
                    {
                        listView.Items.Add(ap.NUMBER_OF_ITEMS +"# "+ap.APPLIANCE_NAME +"(s) WATTS:"+ap.WATTS);
                    }
                }
                else {
                    messageBox("No appliances in the database");
                }
            }
            catch(Exception ex)
            {
                messageBox("error "+ex.Message);
            }
            //listView.ItemsSource = listAppliances;
            base.OnNavigatedTo(e);
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WelcomePage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var sel = listView.SelectedItems.Cast<Object>().ToArray();
            int count = 1; double appliance1Watts = 0.0, appliance2Watts = 0.0,
            appliance3Watts = 0.0, appliance4Watts = 0.0, appliance5Watts = 0.0;
            string[] applianceNames ;
            
            applianceNames = new string[sel.Count()];
            txtAppliance1Hours.Text = "0"; txtAppliance2Hours.Text = "0"; txtAppliance3Hours.Text = "0"; txtAppliance4Hours.Text = "0"; txtAppliance5Hours.Text = "0"; 
            string txtAppliance1 = "";
                string appliance2 = listView.Items[0].ToString();
                try {
               
                for (int i = 0; i < sel.Count(); i++)
                {
                    applianceNames[i] = sel[i].ToString();
                }
                for (int x = 0; x < applianceNames.Count(); x++)
                { 
                    if (applianceNames.Count() >x)
                    {   
                        string myNumbers = "";
                        myNumbers = applianceNames[0];
                        myNumbers = myNumbers.Substring(0,myNumbers.IndexOf('#'));
                        total_numbers_appliance1 = Convert.ToInt32(myNumbers);

                        string myWatts = "";
                        myWatts = applianceNames[0];
                        myWatts = myWatts.Substring(myWatts.IndexOf(':') + 1);
                        appliance1Watts = Convert.ToDouble(myWatts);
                        lblAppliance1.Text = applianceNames[0];

                        txtAppliance1 = txtAppliance1Hours.Text;
                        total_hours_appliance1 = Convert.ToInt32(txtAppliance1);
                    }

                    if (applianceNames.Count() > x+1)
                    {
                        string myNumbers = "";
                        myNumbers = applianceNames[1];
                        myNumbers = myNumbers.Substring(0, myNumbers.IndexOf('#'));
                        total_numbers_appliance2 = Convert.ToInt32(myNumbers);

                        string myWatts = "";
                        myWatts = applianceNames[1];
                        myWatts = myWatts.Substring(myWatts.IndexOf(':') + 1);
                        appliance2Watts = Convert.ToDouble(myWatts); 
                        lblAppliance2.Text = applianceNames[1];

                        string txtAppliance2 = txtAppliance2Hours.Text;
                        total_hours_appliance2 = Convert.ToInt32(txtAppliance2);
                    }    
                    
                    if (applianceNames.Count() > x + 1+1)
                    {
                        string myNumbers = "";
                        myNumbers = applianceNames[2];
                        myNumbers = myNumbers.Substring(0, myNumbers.IndexOf('#'));
                        total_numbers_appliance3 = Convert.ToInt32(myNumbers);

                        string myWatts = "";
                        myWatts = applianceNames[2];
                        myWatts = myWatts.Substring(myWatts.IndexOf(':') + 1);
                        appliance3Watts = Convert.ToDouble(myWatts); 
                        lblAppliance3.Text = applianceNames[2];
                        string txtAppliance3 = txtAppliance3Hours.Text;
                        total_hours_appliance3 = Convert.ToInt32(txtAppliance3);
                    }       
                    
                    if (applianceNames.Count() > x + 1+1+1)
                    {
                        string myNumbers = "";
                        myNumbers = applianceNames[3];
                        myNumbers = myNumbers.Substring(0, myNumbers.IndexOf('#'));
                        total_numbers_appliance4 = Convert.ToInt32(myNumbers);

                        string myWatts = "";
                        myWatts = applianceNames[3];
                        myWatts = myWatts.Substring(myWatts.IndexOf(':') + 1);
                        appliance4Watts = Convert.ToDouble(myWatts); 
                        lblAppliance4.Text = applianceNames[3];

                        string txtAppliance4 = txtAppliance4Hours.Text;
                        total_hours_appliance4 = Convert.ToInt32(txtAppliance4);
                    }

                    if (applianceNames.Count() > x + 1 + 1 + 1 + 1)
                    {
                        string myNumbers = "";
                        myNumbers = applianceNames[4];
                        myNumbers = myNumbers.Substring(0, myNumbers.IndexOf('#'));
                        total_numbers_appliance5 = Convert.ToInt32(myNumbers);

                        string myWatts = "";
                        myWatts = applianceNames[4];
                        myWatts = myWatts.Substring(myWatts.IndexOf(':') + 1);
                        appliance5Watts = Convert.ToDouble(myWatts); 
                        lblAppliance5.Text = applianceNames[4];

                        string txtAppliance5 = txtAppliance5Hours.Text;
                        total_hours_appliance5 = Convert.ToInt32(txtAppliance5);
                    }
                    total_watts = appliance1Watts + appliance2Watts + appliance3Watts + 
                        appliance4Watts + appliance5Watts;
                    tota_number = total_numbers_appliance1 + total_numbers_appliance2 + total_numbers_appliance3 + total_numbers_appliance4 + total_numbers_appliance5;
                    total_hours = total_hours_appliance1 + total_hours_appliance2 + total_hours_appliance3 + total_hours_appliance4 + total_hours_appliance5;
                    
                }
                    //messageBox("Your Kilo watts are " );
                }
                catch (Exception ex)
                {
                    messageBox(" "+ex.Message);
                }
                
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double total_units = 0;
            string appliance1 = txtAppliance1Hours.Text;
            string appliance2 = txtAppliance2Hours.Text;
            string appliance3 = txtAppliance3Hours.Text;
            string appliance4 = txtAppliance4Hours.Text;
            string appliance5 = txtAppliance5Hours.Text;
            string currentUnits = txtCurrentUnits.Text;

            double current_units = Convert.ToDouble(currentUnits);

            double first_appliance_hours = Convert.ToDouble(appliance1);
            double second_appliance_hours = Convert.ToDouble(appliance2);
            double third_appliance_hours = Convert.ToDouble(appliance3);
            double fourth_appliance_hours = Convert.ToDouble(appliance4);
            double fifth_appliance_hours = Convert.ToDouble(appliance5);

            double total_appliance_hours = first_appliance_hours + second_appliance_hours + third_appliance_hours + fourth_appliance_hours + fifth_appliance_hours;
            Kilo_Watts = (total_watts * total_appliance_hours) * tota_number;

            total_units = Kilo_Watts / 1000;
            current_units = current_units - total_units;
            lblRemainingUnits.Text = ""+current_units;
            messageBox("Total consumed Units : "+total_units);
            
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAppliances));
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
      
        /* usersViewModel = new UsersViewModel();
            appliance = new AppliancesViewModel();

            
            try { 
            users = usersViewModel.GetUsers();
            appliances = appliance.getAllAppliances();
            if (users != null)
            {
                
                //namesList = new ListBox();
                //namesList.ItemsSource = usersViewModel;
                foreach (var a in users) { 
                namesList.Items.Add(a.USERNAME);
                    
                }
                
                
                //messageBox("there is data in the table");
            }
            else {
                messageBox("there is no data in the table");
            }
                }
            catch(Exception ex)
            {
                messageBox(ex.Message); 
            }*/
    }
}

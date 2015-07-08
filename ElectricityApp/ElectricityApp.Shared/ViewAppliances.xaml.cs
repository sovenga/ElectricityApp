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
        public ViewAppliances()
        {
            this.InitializeComponent();
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
                        listView.Items.Add(ap.APPLIANCE_NAME);
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
            listView.ItemsSource = listAppliances;
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
            //watts = new TextBox() { Text = "0" };
            //hours = new TextBox() { Text = "0" };
           // number = new TextBox() { Text = "1" };
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var sel = listView.SelectedItems.Cast<Object>().ToArray();
            int count = 0;
            wats = new TextBox[sel.Count()];
                foreach (var it in sel)
                {
                    watts = new TextBox() { Text = "0" };
                    hours = new TextBox() { Text = "0" };
                    number = new TextBox() { Text = "1" };
                    textBoxPanel.Children.Add(watts);
                    
                    textBoxPanel.Children.Add(hours);
                    textBoxPanel.Children.Add(number);
                    wats[count] = watts;
                    watts.Name = "txtApplianceWatts" + count;
                    hours.Name = "txtApplianceHours" + count;
                    number.Name = "txtApplianceNumber" + count;

                    listBox.Items.Add(it);
                    count++;
                } //isPressed = true;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string strWatts = String.Empty; ;
            TextBox textBox = new TextBox() { Text=""};
            int Watts = 0;
            int totalWatts = 0;
            wats = new TextBox[listView.ToString().Count()];
            for (int i = 0; i < listView.ToString().Count(); i++)
            {
                var strWatts1 = wats[i];
                strWatts = strWatts1.Text;
                //Watts = Convert.ToInt32(strWatts);
                //totalWatts += Watts;
                //watt = Convert.ToInt32(strWatts);
                //watt = Convert.ToInt32(strWatts);
                //string n =textBox.Name;
                
            }
            /*if (isPressed == true)
            {
                messageBox("is pressed");
            }
            else { messageBox("is not pressed");}*/
            
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

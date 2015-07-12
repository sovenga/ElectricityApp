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
//using ElectricityCalculatorApp.models;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ElectricityApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPage : Page
    {
        AppliancesViewModel appliance = null;
        ObservableCollection<ApplianceViewModel> appliances = null;
        UsersViewModel usersViewModel = null;
        ObservableCollection<UserViewModel> users = null;
        private App app = (Application.Current as App);
        ObservableCollection<UsersViewModel> strings = new ObservableCollection<UsersViewModel>();
        public ViewPage()
        {
            this.InitializeComponent();
            //strings = usersViewModel.GetUsers();
            //namesList.ItemsSource = stringss;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            usersViewModel = new UsersViewModel();
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
            }
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

        private void namesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

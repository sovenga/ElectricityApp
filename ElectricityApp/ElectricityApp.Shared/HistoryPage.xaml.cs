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
    public sealed partial class HistoryPage : Page
    {
        ObservableCollection<HistoryViewModel> histories= null;
        HistoriesViewModel history = null;
        HistoryViewModel myHistory = null;
        List<History> listHistory = null;
        public HistoryPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            history = new HistoriesViewModel();
            histories = history.getHistory();
            //listViewHistory.Items.Add(histories);
            try
            {
                if (histories != null)
                {
                    foreach (var hist in histories)
                    {
                        listViewHistory.Items.Add("You used "+hist.NUMBER + " appliance'(s) that consumed :" + hist.USED_UNITS + " Units, and Remained units were " + hist.REMAINING_UNITS + " on " + hist.DATE + "");
                    }
                }
                else
                {
                    messageBox("No history in the database");
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
            base.OnNavigatedTo(e);
        }
        private async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            await msgDlg.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAppliances));
        }

        private void btnClearHistory_Click(object sender, RoutedEventArgs e)
        {
            myHistory = new HistoryViewModel();
            try { 
                myHistory.clearHistory();
                messageBox("History has been cleared");
                this.Frame.Navigate(typeof(HistoryPage));
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
            
        }
    }
}

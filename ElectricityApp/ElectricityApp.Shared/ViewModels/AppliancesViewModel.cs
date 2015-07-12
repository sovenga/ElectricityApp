using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace ElectricityApp.ViewModels
{
    class AppliancesViewModel
    {
        private ElectricityApp.App app = (Application.Current as App);
        private ObservableCollection<ApplianceViewModel> appliances;
        public ObservableCollection<ApplianceViewModel> Appliances
        {
            get { return appliances; }

            set
            {
                if (appliances == value)
                {
                    return;
                }
                appliances = value;

            }
        }
        public ObservableCollection<ApplianceViewModel> getAllAppliances()
        {
            appliances = new ObservableCollection<ApplianceViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var query = db.Table<Appliance>();
                
                    foreach(var _appliance in query)
                    {
                        var appliance = new ApplianceViewModel()
                        {
                            ID = _appliance.ID,
                            APPLIANCE_NAME = _appliance.applianceName,
                            WATTS = _appliance.WATTS,
                            NUMBER_OF_ITEMS = _appliance.numberOfAppliances
                        };
                        appliances.Add(appliance);
                    }
            }
            return appliances;
        }
   
        /*public ObservableCollection<UserViewModel> GetUsers()
     {
         users = new ObservableCollection<UserViewModel>();

         using (var db = new SQLite.SQLiteConnection(app.DBPath))
         {
             var query = db.Table<User>();
             foreach (var _users in query)
             {
                 var user = new UserViewModel()
                 {
                     USERNAME = _users.USER_EMAIL,
                     PASSWORD = _users.PASSWORD
                 };
                 users.Add(user);
             }
         }
         return users;
     }*/
    }
}

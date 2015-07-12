using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace ElectricityApp.ViewModels
{
    
    class ApplianceViewModel
    {
        private ElectricityApp.App app = (Application.Current as App);
        private int id = 0;
        public int ID 
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
            }
        }

        private string applianceName = string.Empty;
        public string APPLIANCE_NAME
        {
            get { return applianceName; }
            set
            {
                if (applianceName == value)
                {
                    return;
                }
                applianceName = value;
            }
        }
        private int watts = 0;
        public int WATTS
        {
            get { return watts; }
            set
            {
                if (watts == value)
                {
                    return;
                }
                watts = value;
            }
        }

        private int numberOfItems = 0;
        public int NUMBER_OF_ITEMS
        {
            get { return numberOfItems; }
            set
            {
                if (numberOfItems == value)
                {
                    return;
                }
                numberOfItems = value;
            }
        }
        public void addAppliance(string name, int watts, int number)
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath)) 
            {
                try
                {
                    int data = db.Insert(new Appliance()
                    {
                        ID = 0,
                        applianceName = name,
                        WATTS = watts,
                        numberOfAppliances = number
                    });
                }
                catch (Exception e)
                { 
                    //result = "This Appliance was not saved";
                }
            }

        }
       
        public void dropAppliancesTable()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                db.DropTable<Appliance>();
            }
        }
        public void deleteAllAppliances()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                db.DropTable<Appliance>();
                    var data = db.Table<Appliance>();
                    if (db.Delete(data) > 0)
                    {

                    }
                    else { 
                        
                    }   
            
            }
        }
        public void deleteAllUsers()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var data = db.Table<User>();
                if (db.Delete(data) > 0)
                { 
                    
                }
                
            }

        }
        public void deleteAllUsersVersion2()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var data = db.Query<User>("delete from Appliance");
                if (db.Delete(data) > 0)
                {

                }

            }

        }

        public List<Appliance> getAppliance(string name)
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var existingUser = db.Query<Appliance>("select * from Appliance where applianceName = '" + name + "'");
                return existingUser;
            }
        }
       
     
    }
}


using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace ElectricityApp.ViewModels
{
    class HistoryViewModel
    {
        private ElectricityApp.App app = (Application.Current as App);
        private int id = 0;
        public int ID {
            get { return id; }

            set {
                if(id == value){
                    return;
                }
                  id = value; 
            }
           
        }
        private int number = 0;
        public int NUMBER
        {
            get { return number; }

            set
            {
                if (number == value)
                {
                    return;
                }
                number = value;
            }

        }
        private double current_units = 0.0;
        public double USED_UNITS { 
            get { return current_units; }
            set
            {
                if(current_units == value)
                {
                    return;
                }
                current_units = value;
            }
        }

        private double remaining_units = 0.0;
        public double REMAINING_UNITS
        {
            get { return remaining_units; }
            set
            {
                if (remaining_units == value)
                {
                    return;
                }
                remaining_units = value;
            }
        }
        private string date = String.Empty;
        public string DATE {
            get 
            { return date; } 
            set 
            {
                if (date == value)
                {
                    return; 
                } 
                date = value; 
            }
        }
        public void saveHistory(int numberOfAppliances, double usedWatts, double remaining_watts, string date)
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                try
                {
                    int data = db.Insert(new History()
                    {
                        ID = 0,
                        number_of_appliances = numberOfAppliances,
                        used_watts = usedWatts,
                        remaining_watts = remaining_watts,
                        date = date
                    });
                }
                catch (Exception e)
                {
                    //result = "This Appliance was not saved";
                }
            }
        }
        public void clearHistory()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var existingUser = db.Query<History>("delete from history");
            }

        }
        public void dropHistory()
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                db.DropTable<History>();
                var data = db.Table<History>();
                if (db.Delete(data) > 0)
                {

                }
            }
        }
    }
}

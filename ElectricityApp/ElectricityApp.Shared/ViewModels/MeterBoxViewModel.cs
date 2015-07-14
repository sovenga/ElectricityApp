using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityApp.ViewModels
{
    class MeterBoxViewModel
    {
        private int id = 0;
        public int ID { 
            get {return id;}
            set{
                if(id == value)
                {return;}
                id = value;
            }
        }
        private string meter_number = String.Empty;
        public string METER_NUMBER {
            get { return meter_number; }
            set
            {
                if(meter_number == value)
                { return; }
                meter_number = value;
            }
        }
        private double current_units = 0.0;
        public double CURRENT_UNITS
        {
            get { return current_units; }
            set
            {
                if (current_units == value)
                {
                    return;
                }
                current_units = value;
            }
        }
        public void addMeterBox(string meterBoxNumber,double current)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
                try
                {
                    int success = db.Insert(new MeterBox()
                    {
                        ID = 0,
                        meterBoxNumber = meterBoxNumber,
                        currentUnits = current
                    });
                }
                catch (Exception e)
                {

                }
            //return "Success";
        }
        public void updateMeterBox(double current)
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                try
                {
                    db.ExecuteUpdate("update meterbox set currentUnits = "+current);

                }
                catch (Exception e)
                {
                    
                }
            }
        }
    }
}

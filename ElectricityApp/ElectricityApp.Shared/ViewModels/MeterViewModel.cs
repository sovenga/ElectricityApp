using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using System.Linq;

namespace ElectricityApp.ViewModels
{
    class MeterViewModel
    {
        
            private ElectricityApp.App app = (Application.Current as App);
            private int id = 0;
            public int ID
            {
                get { return id; }
                set
                {
                    if (id == value)
                    { return; }
                    id = value;
                }
            }
            private string meter_number = String.Empty;
            public string METER_NUMBER
            {
                get { return meter_number; }
                set
                {
                    if (meter_number == value)
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
            public void addMeterBox(string meterBoxNumber, double current)
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
            public void updateMeterBoxUnits(double used)
            {
                double rem = 0.0;
                using (var db = new SQLite.SQLiteConnection(app.DBPath))
                {
                    try
                    {
                       // rem = current - used;
                        db.Execute("update meterbox set currentUnits = currentUnits -" + used);
                        var query = db.Table<MeterBox>();
                        {
                            CURRENT_UNITS = CURRENT_UNITS - used;
                        }
                        db.Update(query);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            public MeterBox getMeterUnits()
            {
                using (var db = new SQLite.SQLiteConnection(app.DBPath))
                {
                    var q = db.Query<MeterBox>("select * from MeterBox").FirstOrDefault();
                    return q;
                }
            }
            public void removeMeters()
            {
                using (var db = new SQLite.SQLiteConnection(app.DBPath))
                {
                    var q = db.Query<MeterBox>("delete from MeterBox");
                }
            }
    }
}

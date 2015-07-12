using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityApp.model
{
    class Appliance
    {
       [SQLite.PrimaryKey,SQLite.AutoIncrement]
        public int ID { get; set; }
        public string applianceName { get; set; }
        public int WATTS { get; set; }
        public int numberOfAppliances { get; set; }
    }
}

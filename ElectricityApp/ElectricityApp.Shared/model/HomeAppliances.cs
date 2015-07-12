using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityApp.model
{
    class HomeAppliances
    {
        [SQLite.AutoIncrement]
        public int ID { get; set; }
        public string applianceName { get; set; }
        public string watts { get; set; }
        public string numberOfAppliances { get; set; }
        public string hoursUsed { get; set; }

    }
}

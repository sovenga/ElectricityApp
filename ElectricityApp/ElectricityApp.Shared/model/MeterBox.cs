using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityApp.model
{
    class MeterBox
    {
        [SQLite.PrimaryKey,SQLite.AutoIncrement]
        public int ID { get; set; }
        public string meterBoxNumber { get; set; }
        public double currentUnits { get; set; }

    }
}

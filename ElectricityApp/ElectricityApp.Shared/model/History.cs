using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityApp.model
{
    class History
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public int number_of_appliances { get; set; }
        public double used_watts { get; set; }
        public double remaining_watts { get; set; }
        public string date { get; set; }

    }
}

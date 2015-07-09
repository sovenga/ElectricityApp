using System;
using System.Collections.Generic;
using System.Text;
using ElectricityApp;
using System.Linq;
using Windows.UI.Xaml;
namespace ElectricityApp.model
{
    class UserViewModel
    {
        

        private string userName = string.Empty;
        public string USERNAME 
        {
            get { return userName; }

            set {
                if (userName == value)
                { return; }

                userName = value;
                
            }
        }
        private ElectricityApp.App app = (Application.Current as App);
        private string password = string.Empty;
        public string PASSWORD 
        {
            get { return password; }

            set
            {
                if (password == value)
                { return; }
                password = value;
            }
        }
        public void addUser(string username, string password)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            try {
                int success = db.Insert(new User() 
                {
                    USER_EMAIL = username,
                    PASSWORD = password
                });
            }
            catch (Exception e)
            {
                
            }
        }
        public User getUser(string username,string password)
        {
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var existingUser = db.Query<User>("select * from User where USER_EMAIL = '" + username + "' and PASSWORD = '" + password+"'").FirstOrDefault();
                return existingUser;
            }
        }
        
    }
}

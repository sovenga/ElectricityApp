using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ElectricityApp.ViewModels
{
    class UsersViewModel
    {
        private ObservableCollection<UserViewModel> users;
        public ObservableCollection<UserViewModel> Users
        {
            get { return users; }
            set 
            {
                users = value;
            }
        }

        private ObservableCollection<UserViewModel> groupedUsers;
        private ObservableCollection<UserViewModel> GroupedUsers
        {
            get { return users; }

            set { users = value; }
        }

        private App app = (Application.Current as App);

        public ObservableCollection<UserViewModel> GetUsers()
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
        }


    }
}

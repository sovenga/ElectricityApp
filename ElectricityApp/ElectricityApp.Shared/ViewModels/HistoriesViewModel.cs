using ElectricityApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace ElectricityApp.ViewModels
{
    class HistoriesViewModel
    {
        private ElectricityApp.App app = (Application.Current as App);
        private ObservableCollection<HistoryViewModel> history;
        public ObservableCollection<HistoryViewModel> History
        {
            get { return history; }
            set
            {
                if(history == value)
                { return; }
                history = value;
            }

        }
        public ObservableCollection<HistoryViewModel> getHistory()
        {
            history = new ObservableCollection<HistoryViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var query = db.Table<History>();
                foreach(var _history in query)
                {
                    var histories = new HistoryViewModel()
                    {
                        ID = _history.ID,
                        USED_UNITS = _history.used_watts,
                        REMAINING_UNITS = _history.remaining_watts,
                        DATE = _history.date
                    };
                    history.Add(histories);
                }
            }
            return history;

        }

    }
}

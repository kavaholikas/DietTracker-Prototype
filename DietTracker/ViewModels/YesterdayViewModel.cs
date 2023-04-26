using CommunityToolkit.Mvvm.ComponentModel;
using DietTracker.Models;
using DietTracker.Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietTracker.ViewModels
{
    public partial class YesterdayViewModel : ObservableObject
    {
        private readonly Tracker.Tracker _tracker;

        private bool _noHistory;

        private DietDay? _yesterday;

        [ObservableProperty]
        private DietDayModel dietDayModel;

        public bool ShowYesterday => !_noHistory;
        public bool ShowNoHistory => _noHistory;

        public YesterdayViewModel(Tracker.Tracker tracker)
        {
            _tracker = tracker;
            _getYesterday();
        }

        private void _getYesterday()
        {
            _yesterday = _tracker.GetLastDay();
            _noHistory = _yesterday == null;

            if (_yesterday != null)
            {
                DietDayModel = new DietDayModel(_yesterday);
            }

            OnPropertyChanged(nameof(ShowYesterday));
            OnPropertyChanged(nameof(ShowNoHistory));
        }

        public void OnAppearing()
        {
            _getYesterday();
        }
    }
}

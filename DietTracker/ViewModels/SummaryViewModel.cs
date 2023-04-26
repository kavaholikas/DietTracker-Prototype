using CommunityToolkit.Mvvm.ComponentModel;
using DietTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietTracker.ViewModels
{
    public partial class SummaryViewModel : ObservableObject
    {
        private readonly Tracker.Tracker _tracker;

        private List<DietDay> _days;

        public ObservableCollection<DietDayModel> Days => new ObservableCollection<DietDayModel>(_days.Select(d => new DietDayModel(d)).Reverse());

        public bool ShowSummary => _days.Count > 0;
        public bool NoSummary => _days.Count < 1;

        public SummaryViewModel(Tracker.Tracker tracker)
        {
            _tracker = tracker;
            _getDays();
        }

        private void _getDays()
        {
            _days = _tracker.GetDays();

            OnPropertyChanged(nameof(Days));
            OnPropertyChanged(nameof(ShowSummary));
            OnPropertyChanged(nameof(NoSummary));
        }

        public void OnAppearing()
        {
            _getDays();
        }
    }
}

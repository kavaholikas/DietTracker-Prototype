using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DietTracker.Messages;
using DietTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DietTracker.ViewModels
{
    public partial class TodayViewModel : ObservableObject
    {
        private readonly Tracker.Tracker _tracker;

        //public ObservableCollection<DietEntry> Entries => new ObservableCollection<DietEntry>(_tracker.CurrentDayEntries);
        public ObservableCollection<DietEntryModel> Entries =>
            new ObservableCollection<DietEntryModel>(_tracker.CurrentDayEntries.Select(e => new DietEntryModel(e)));

        public string Date => _tracker.CurrentDayDate;

        [ObservableProperty]
        private string foodEntry;

        public ICommand AddDietEntryCommand { get; }

        public TodayViewModel(Tracker.Tracker tracker)
        {
            _tracker = tracker;

            AddDietEntryCommand = new RelayCommand(AddDietEntry);

            WeakReferenceMessenger.Default.Register<RemoveDietEntryMessage>(this, (r, m) => RemoveDietEntry(m.Value.EntryID));
            WeakReferenceMessenger.Default.Register<UpdateEntryNameMessage>(this, (r, m) => UpdateEntryName(m.Value.EntryID, m.Value.FoodEntryUpdate));
            WeakReferenceMessenger.Default.Register<OnResumeMessage>(this, (r, m) => OnAppearing(true));
        }

        public void AddDietEntry()
        {
            if (!string.IsNullOrEmpty(FoodEntry))
            {
                DietEntry entry = new DietEntry(DateTime.Now, FoodEntry);
                _tracker.AddNewEntry(entry);

                FoodEntry = string.Empty;
                OnPropertyChanged(nameof(Entries));
            }
        }

        public void RemoveDietEntry(Guid id)
        {
            _tracker.RemmoveEntry(id);
            OnPropertyChanged(nameof(Entries));
        }

        public void UpdateEntryName(Guid id, string newName)
        {
            _tracker.UpdateEntryName(id, newName);
            OnPropertyChanged(nameof(Entries));
        }

        public void OnAppearing(bool resume = false)
        {
            bool newDay = _tracker.TestIfItsNewDay();

            if (newDay)
            {
                _tracker.PushDayToList();
                OnPropertyChanged(nameof(Entries));
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}

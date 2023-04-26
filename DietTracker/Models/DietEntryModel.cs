using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DietTracker.Messages;
using DietTracker.Models;

namespace DietTracker.Models
{
    public partial class DietEntryModel : ObservableObject
    {
        private readonly DietEntry _entry;

        [ObservableProperty]
        private bool showUpdate = false;

        [ObservableProperty]
        private string foodEntryUpdate;

        public Guid EntryID => _entry.EntryID;
        public string TimeString => _entry.TimeString;
        public string Name => _entry.Name;

        public ICommand RemoveDietEntryCommand { get; }
        public ICommand ToggleShowUpdateCommand { get; }
        public ICommand UpdateEntryNameCommand { get; }

        public DietEntryModel(DietEntry entry)
        {
            _entry = entry;

            RemoveDietEntryCommand = new RelayCommand(RemoveDietEntry);
            ToggleShowUpdateCommand = new RelayCommand(ToggleShowUpdate);
            UpdateEntryNameCommand= new RelayCommand(UpdateEntryName);
        }

        public void RemoveDietEntry()
        {
            WeakReferenceMessenger.Default.Send(new RemoveDietEntryMessage(this));
        }

        public void ToggleShowUpdate()
        {
            ShowUpdate = !ShowUpdate;
        }

        public void UpdateEntryName()
        {
            WeakReferenceMessenger.Default.Send(new UpdateEntryNameMessage(this));

            FoodEntryUpdate = string.Empty;
            ShowUpdate = false;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DietTracker.Models
{
    public partial class DietDayModel: ObservableObject
    {
        private readonly DietDay _dietDay;

        public string DateString => _dietDay.Date.ToString("yyyy-MM-dd");

        public List<DietEntry> Entries => _dietDay.GetEntries();
        public int EntryCount => Entries.Count;

        [ObservableProperty]
        private bool showMore = false;

        public ICommand ToggleShowMoreCommand { get; }

        public DietDayModel(DietDay dietDay)
        {
            _dietDay = dietDay;
            ToggleShowMoreCommand = new RelayCommand(ToggleShowMore);
        }

        public void ToggleShowMore()
        {
            ShowMore = !ShowMore;
        }
    }
}

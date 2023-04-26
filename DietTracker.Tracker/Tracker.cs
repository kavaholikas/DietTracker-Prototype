using DietTracker.MockStore;
using DietTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietTracker.Tracker
{
    public class Tracker
    {
        private readonly IStore _store;

        public List<DietDay> Days { get; set; } = new List<DietDay>();

        public DietDay CurrentDay { get; private set; }

        public string CurrentDayDate => CurrentDay.Date.ToString("yyyy-MM-dd");

        public List<DietEntry> CurrentDayEntries => CurrentDay.GetEntries();

        public Tracker(IStore store)
        {
            _store = store;
            LoadData();

            if (CurrentDay == null)
            {
                CreateNewDay();
            }
        }

        public void CreateNewDay(DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Now.Date;
            }

            CurrentDay = new DietDay(date.Value);
        }

        public DietDay? GetLastDay()
        {
            return Days.Count == 0 ? null : Days.Last();
        }

        public List<DietDay> GetDays(int count = 7)
        {
            if (Days.Count < count)
            {
                return Days;
            }

            return Days.GetRange(Days.Count - count, count);
        }

        public bool TestIfItsNewDay(DateTime? date = null)
        {
            if (CurrentDay == null)
            {
                return true;
            }

            if (date == null)
            {
                date = DateTime.Now.Date;
            }

            return date > CurrentDay.Date;
        }

        public void PushDayToList(DateTime? date = null)
        {
            if (CurrentDayEntries.Count == 0)
            {
                CreateNewDay(date);
                return;
            }

            int index = Days.FindIndex(d => d.Date == CurrentDay.Date);

            if (index != -1)
            {
                Days[index] = CurrentDay;
            }
            else
            {
                // This may keep reference to CurrentDay and override old data afterwards
                Days.Add(CurrentDay);
            }

            CreateNewDay(date);
        }

        #region Entry Managment
        public void AddNewEntry(DietEntry entry)
        {
            CurrentDay.AddNewEntry(entry);
        }

        public DietEntry? GetEntry(Guid id)
        {
            return CurrentDay.GetEntries().Find(e => e.EntryID == id);
        }

        public void UpdateEntry(Guid id, string name, DateTime time)
        {
            CurrentDay.UpdateEntry(id, name, time);
        }

        public void UpdateEntryName(Guid id, string name)
        {
            CurrentDay.UpdateEntryName(id, name);
        }

        public void UpdateEntryTime(Guid id, DateTime time)
        {
            CurrentDay.UpdateEntryTime(id, time);
        }

        public void RemmoveEntry(Guid id)
        {
            CurrentDay.RemoveEntry(id);
        }
        #endregion


        public void LoadData()
        {
            (Days, CurrentDay) = _store.Load();
        }

        public void SaveData()
        {

        }
    }
}

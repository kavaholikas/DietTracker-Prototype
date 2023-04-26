using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietTracker.Models
{
    public class DietDay
    {
        public DateTime Date { get; set; }

        private List<DietEntry> _entries;

        public DietDay(DateTime date)
        {
            Date = date;
            _entries = new List<DietEntry>();
        }

        public void AddNewEntry(DietEntry entry)
        {
            _entries.Add(entry);
        }

        public List<DietEntry> GetEntries()
        {
            return _entries;
        }

        public DietEntry? GetEntry(Guid id)
        {
            return _entries.Find(e => e.EntryID == id);
        }

        public bool UpdateEntry(Guid id, string name, DateTime time)
        {
            bool result = UpdateEntryName(id, name);

            if (!result)
            {
                return false;
            }

            result = UpdateEntryTime(id, time);

            return result;
        }

        public bool UpdateEntryTime(Guid id, DateTime time)
        {
            int index = _entries.FindIndex(e => e.EntryID == id);

            if (index == -1)
            {
                return false;
            }

            _entries[index].SetTime(time);
            return true;
        }

        public bool UpdateEntryName(Guid id, string name)
        {
            int index = _entries.FindIndex(e => e.EntryID == id);

            if (index == -1)
            {
                return false;
            }

            _entries[index].SetName(name);
            return true;    
        }

        public bool RemoveEntry(Guid id)
        {
            int index = _entries.FindIndex(e => e.EntryID == id);

            if (index == -1)
            {
                return false;
            }

            _entries.RemoveAt(index);

            return true;
        }
    }
}

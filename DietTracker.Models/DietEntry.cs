using System;
using System.Collections.Generic;
using System.Text;

namespace DietTracker.Models
{
    public class DietEntry
    {
        public Guid EntryID { get; private set; }
        public DateTime Time { get; private set; }
        public string Name { get; private set; }

        public void SetTime(DateTime time) => Time = time;
        public void SetName(string name) => Name = name;

        public string TimeString => Time.ToString("HH:mm:ss");

        public DietEntry()
        {
            EntryID = Guid.NewGuid();
        }

        public DietEntry(DateTime time, string name)
        {
            EntryID = Guid.NewGuid();
            Time = time;
            Name = name;
        }

    }
}

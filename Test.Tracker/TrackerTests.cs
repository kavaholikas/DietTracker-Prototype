namespace Test.Tracker
{
    public class TrackerTests
    {
        [Fact]
        public void IsTrackerConstructedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            Assert.NotNull(tracker.CurrentDay);
        }

        [Fact]
        public void IsNewDayCreatedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            tracker.CreateNewDay();
            Assert.NotNull(tracker.CurrentDay);
        }

        [Fact]
        public void IsNewDayWithCustomDateCreatedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime date = DateTime.Now.Date;
            tracker.CreateNewDay(date);

            Assert.Equal(date, tracker.CurrentDay.Date);
        }

        [Fact]
        public void IsCurrentDayDateFormatCorrect()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime date = DateTime.Now.Date;
            tracker.CreateNewDay(date);

            string dateFormat = date.ToString("yyyy-MM-dd");

            Assert.Equal(dateFormat, tracker.CurrentDayDate);
        }

        [Fact]
        public void IsEmptyEntryListReturnedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            List<DietEntry> entries = tracker.CurrentDayEntries;
            Assert.Empty(entries);
        }

        [Fact]
        public void AreEntriesAddedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            int count = tracker.CurrentDayEntries.Count;
            tracker.AddNewEntry(entry);

            Assert.Multiple(
                () => Assert.NotEmpty(tracker.CurrentDayEntries),
                () => Assert.Equal(1, count + 1),
                () => Assert.Equal(entry, tracker.CurrentDayEntries.Last())
            );
        }

        [Fact]
        public void IsCorrectEntryReturn()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            tracker.AddNewEntry(entry);

            Assert.Equal(entry, tracker.GetEntry(entry.EntryID));
        }

        [Fact]
        public void IsNullReturnedForIncorrectEntryId()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            tracker.AddNewEntry(entry);

            Assert.Null(tracker.GetEntry(Guid.NewGuid()));
        }

        [Fact]
        public void IsEntryNameUpdatedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            string newName = "Pasta";

            tracker.AddNewEntry(entry);
            tracker.UpdateEntryName(entry.EntryID, newName);

            Assert.Equal(newName, tracker.GetEntry(entry.EntryID)?.Name);
        }

        [Fact]
        public void IsEntryTimeUpdatedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);


            DateTime newTime = DateTime.Now.AddMinutes(15);
            tracker.AddNewEntry(entry);
            tracker.UpdateEntryTime(entry.EntryID, newTime);

            Assert.Equal(newTime, tracker.GetEntry(entry.EntryID)?.Time);
        }

        [Fact]
        public void IsEntryUpdatedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);


            string newName = "Pasta";
            DateTime newTime = DateTime.Now.AddMinutes(15);
            tracker.AddNewEntry(entry);
            tracker.UpdateEntry(entry.EntryID, newName, newTime);

            Assert.Multiple(
                () => Assert.Equal(newName, tracker.GetEntry(entry.EntryID)?.Name),
                () => Assert.Equal(newTime, tracker.GetEntry(entry.EntryID)?.Time)
            );
        }

        [Fact]
        public void IsEntryRemovedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            tracker.AddNewEntry(entry);
            int count = tracker.CurrentDayEntries.Count;

            tracker.RemmoveEntry(entry.EntryID);

            Assert.Multiple(
                () => Assert.Equal(count - 1, tracker.CurrentDayEntries.Count),
                () => Assert.Empty(tracker.CurrentDayEntries)
            );
        }

        [Fact]
        public void DoesNewDayTestFailsOnSameDay()
        {
            DietTracker.Tracker.Tracker tracker = new();

            bool result = tracker.TestIfItsNewDay();
            Assert.False(result);
        }

        [Fact]
        public void DoesNewDayTestSucceedsOnNextDay()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime date = DateTime.Now.Date;
            tracker.CreateNewDay(date);

            DateTime nextDay = DateTime.Now.AddDays(1).Date;

            bool result = tracker.TestIfItsNewDay(nextDay);

            Assert.True(result);
        }

        [Fact]
        public void DoesTrackerPushesDayToListCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime oldDate = DateTime.Now.Date;
            DateTime newDate = DateTime.Now.AddDays(1).Date;

            string dishName = "Chicken Nuggets";

            tracker.CreateNewDay(oldDate);
            tracker.AddNewEntry(new DietEntry(DateTime.Now, dishName));
            tracker.PushDayToList(newDate);

            Assert.Multiple(
                () => Assert.Equal(newDate, tracker.CurrentDay.Date),
                () => Assert.NotEmpty(tracker.Days[0].GetEntries()),
                () => Assert.Empty(tracker.CurrentDayEntries)
            );
        }

        [Fact]
        public void IsLastDayReturnedCorrectly()
        {
            DietTracker.Tracker.Tracker tracker = new();
            tracker.AddNewEntry(new DietEntry(DateTime.Now, "Chicken Nuggets"));

            DateTime tomorrow = DateTime.Now.AddDays(1).Date;
            tracker.PushDayToList(tomorrow);
            DietDay? day = tracker.GetLastDay();

            Assert.NotNull(day);
        }

        [Fact]
        public void IsLastDayReturnsNullWhenEmpty()
        {
            DietTracker.Tracker.Tracker tracker = new();

            DateTime tomorrow = DateTime.Now.AddDays(1).Date;
            tracker.PushDayToList(tomorrow);
            DietDay? day = tracker.GetLastDay();

            Assert.Null(day);
        }
    }
}

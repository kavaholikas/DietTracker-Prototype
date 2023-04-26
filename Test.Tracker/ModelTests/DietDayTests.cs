namespace Test.Tracker.ModelTests.ModelTests
{
    public class DietDayTests
    {
        [Fact]
        public void IsDietDayConstructedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            Assert.Multiple(
                () => Assert.Equal(date, day.Date),
                () => Assert.Empty(day.GetEntries())
            );
        }

        [Fact]
        public void IsNewEntryAddedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            Assert.Multiple(
                () => Assert.NotEmpty(day.GetEntries()),
                () => Assert.Equal(entry, day.GetEntries().Last())
            );
        }

        [Fact]
        public void AreEntriesReturnedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            List<DietEntry> entries = day.GetEntries();

            Assert.NotEmpty(entries);
        }

        [Fact]
        public void IsEntryReturnedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            DietEntry? newEntry = day.GetEntry(entry.EntryID);

            Assert.Equal(entry, newEntry);
        }

        [Fact]
        public void IsBadEntryReturnedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            DietEntry? newEntry = day.GetEntry(Guid.NewGuid());

            Assert.Null(newEntry);
        }

        [Fact]
        public void IsEntryUpdatedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            string newName = "Pasta";
            DateTime newTime = DateTime.Now.AddMinutes(15);
            bool result = day.UpdateEntry(entry.EntryID, newName, newTime);

            Assert.Multiple(
                () => Assert.True(result),
                () => Assert.Equal(newName, day.GetEntry(entry.EntryID)?.Name),
                () => Assert.Equal(newTime, day.GetEntry(entry.EntryID)?.Time)
            );
        }

        [Fact]
        public void IsEntryNameUpdatedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            string newName = "Pasta";
            bool result = day.UpdateEntryName(entry.EntryID, newName);

            Assert.Multiple(
                () => Assert.True(result),
                () => Assert.Equal(newName, day.GetEntry(entry.EntryID)?.Name)
            );
        }

        [Fact]
        public void IsEntryTimeUpdatedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            DateTime newTime = DateTime.Now.AddMinutes(15);
            bool result = day.UpdateEntryTime(entry.EntryID, newTime);

            Assert.Multiple(
                () => Assert.True(result),
                () => Assert.Equal(newTime, day.GetEntry(entry.EntryID)?.Time)
            );
        }

        [Fact]
        public void IsEntryRemovedCorrectly()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            int count = day.GetEntries().Count();
            bool result = day.RemoveEntry(entry.EntryID);

            Assert.Multiple(
                () => Assert.True(result),
                () => Assert.Equal(0, count - 1),
                () => Assert.Empty(day.GetEntries())
            );
        }

        [Fact]
        public void IsBadEntryRemovalCorrect()
        {
            DateTime date = DateTime.Now.Date;
            DietDay day = new DietDay(date);

            DateTime time = DateTime.Now;
            string name = "Chicken Nuggets";
            DietEntry entry = new DietEntry(time, name);

            day.AddNewEntry(entry);

            int count = day.GetEntries().Count();
            bool result = day.RemoveEntry(Guid.NewGuid());

            Assert.Multiple(
                () => Assert.False(result),
                () => Assert.Equal(count, day.GetEntries().Count()),
                () => Assert.NotEmpty(day.GetEntries())
            );
        }
    }
}

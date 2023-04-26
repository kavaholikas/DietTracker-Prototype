namespace Test.Tracker.ModelTests
{
    public class DietEntryTests
    {
        public static readonly object[][] DietEntryTheoryData =
        {
            new object[] { "Chicken Nuggets", DateTime.Parse("2023-04-22 08:14") },
            new object[] { "Fried Rice", DateTime.Parse("2023-03-22 18:14") },
            new object[] { "Cezar Salads", DateTime.Parse("2023-04-18 12:32") },
            new object[] { "Frozen Yogurt", DateTime.Parse("2022-01-15 10:24") },
        };

        [Theory, MemberData(nameof(DietEntryTheoryData))]
        public void IsDietEntryConstructedCorrectly(string name, DateTime time)
        {
            string Name = name;
            DateTime Time = time;

            DietEntry entry = new DietEntry(Time, Name);

            Assert.Multiple(() => Assert.Equal(Name, entry.Name),
                () => Assert.Equal(Time, entry.Time),
                () => Assert.False(string.IsNullOrEmpty(entry.EntryID.ToString()))
            );
        }

        [Fact]
        public void IsNameSetCorrectly()
        {
            string name = "Chicken Nuggets";
            DateTime time = DateTime.Now;
            DietEntry entry = new DietEntry(time, name);

            string newName = "Pasta";
            entry.SetName(newName);
            Assert.Equal(newName, entry.Name);
        }

        [Fact]
        public void IsTimeSetCorrectly()
        {
            string name = "Chicken Nuggets";
            DateTime time = DateTime.Now;
            DietEntry entry = new DietEntry(time, name);

            DateTime newTime = DateTime.Now.AddMinutes(15);
            entry.SetTime(newTime);
            Assert.Equal(newTime, entry.Time);
        }
    }
}
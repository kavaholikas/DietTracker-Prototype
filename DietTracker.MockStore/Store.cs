using DietTracker.Models;
using System.Text.Json;

namespace DietTracker.MockStore
{
    public class Store : IStore
    {
        private List<DietDay> _days = new();
        private DietDay _currentDay;

        public Store()
        {
            _currentDay = new DietDay(DateTime.Now.Date);
            _currentDay.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3), "Chicken Nuggets"));
            _currentDay.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2), "Pasta"));
            _currentDay.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1), "Protein Shake"));

            DietDay dayOne = new DietDay(DateTime.Now.AddDays(-2).Date);
            dayOne.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-2), "Bannana"));
            dayOne.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-2), "Curd"));
            dayOne.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-2), "Omlet"));

            _days.Add(dayOne);

            DietDay dayTwo = new DietDay(DateTime.Now.AddDays(-1).Date);
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-3).AddDays(-1), "Beans"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-2).AddDays(-1), "Beef"));
            dayTwo.AddNewEntry(new DietEntry(DateTime.Now.AddHours(-1).AddDays(-1), "Burger"));

            _days.Add(dayTwo);
        }

        public (List<DietDay>, DietDay) Load()
        {
            return (_days, _currentDay);
        }

        public void Save(List<DietDay> days, DietDay currentDay)
        {
            _days = JsonSerializer.Deserialize<List<DietDay>>(JsonSerializer.Serialize<List<DietDay>>(days)) ?? days;
            _currentDay = JsonSerializer.Deserialize<DietDay>(JsonSerializer.Serialize<DietDay>(currentDay)) ?? currentDay;
        }
    }
}

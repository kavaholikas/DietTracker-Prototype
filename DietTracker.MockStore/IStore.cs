using DietTracker.Models;

namespace DietTracker.MockStore
{
    public interface IStore
    {
        public void Save(List<DietDay> days, DietDay currentDay);
        public (List<DietDay>, DietDay) Load();
    }
}

namespace Laboratorium_nr3.Models
{
    public interface ITravelService
    {
        void Add(Travel travel);
        void Update(Travel travel);
        void DeleteById(int id);
        Travel? FindById(int id);
        Dictionary<int, Travel> GetAll();
        
    }
}

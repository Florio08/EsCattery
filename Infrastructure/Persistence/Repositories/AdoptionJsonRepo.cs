using Application.Interfaces;
using Domain.Model.Entities;
using Infrastructure.Persistence.Dto;
using System.Text.Json;
using Infrastructure.Persistence.Mappers;

namespace Infrastructure.Persistence.Repositories
{
    public class AdoptionJsonRepo : IAdoptionRepo
    {
        private readonly string _filePath = "adoptions.json";
        private List<Adoption> _cache = new List<Adoption>();

        public AdoptionJsonRepo()
        {
            EnsureLoaded();
        }
        private void EnsureLoaded()
        {
            if (_cache.Count > 0) return;

            if (!File.Exists(_filePath))
            {
                // file mancante -> cache vuota (già inizializzata)
                return;
            }

            var json = File.ReadAllText(_filePath);
            var dtoList = JsonSerializer.Deserialize<List<AdoptionPercistenceDto>>(json) ?? new List<AdoptionPercistenceDto>();

            for (int i = 0; i < dtoList.Count; i++)
            {
                _cache.Add(dtoList[i].ToEntity());
            }
        }

        public IEnumerable<Adoption> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }

        public void AddToRepo(Adoption itemToAdd)
        {
            EnsureLoaded();
            _cache.Add(itemToAdd);

            var dtoValues = new List<AdoptionPercistenceDto>();
            for (int i = 0; i < _cache.Count; i++)
            {
                dtoValues.Add(_cache[i].ToDto());
            }

            var json = JsonSerializer.Serialize(dtoValues);
            File.WriteAllText(_filePath, json);
        }

        public void RemoveFromRepo(Adoption itemToRemove)
        {
            EnsureLoaded();
            _cache.Remove(itemToRemove);

            var dtoValues = new List<AdoptionPercistenceDto>();
            for (int i = 0; i < _cache.Count; i++)
            {
                dtoValues.Add(_cache[i].ToDto());
            }

            var json = JsonSerializer.Serialize(dtoValues);
            File.WriteAllText(_filePath, json);
        }

        public void Update(Adoption itemToUpdate)
        {
            EnsureLoaded();
            for (int i = 0; i < _cache.Count; i++)
            {
                if (_cache[i].Equals(itemToUpdate))
                {
                    _cache[i] = itemToUpdate;
                    break;
                }
            }
        }
    }
}
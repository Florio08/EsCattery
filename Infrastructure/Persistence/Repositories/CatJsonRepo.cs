using Application.Interfaces;
using Domain.Model.Entities;
using Infrastructure.Persistence.Dto;
using System.Text.Json;
using Infrastructure.Persistence.Mappers;

namespace Infrastructure.Persistence.Repositories
{
    public class CatJsonRepo : ICatRepo
    {
        private List<Cat> _cache = new List<Cat>();
        private string _filePath = "cats.json";
        public CatJsonRepo()
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
            var dtoList = JsonSerializer.Deserialize<List<CatPercistenceDto>>(json) ?? new List<CatPercistenceDto>();

            for (int i = 0; i < dtoList.Count; i++)
            {
                _cache.Add(dtoList[i].ToEntity());
            }
        }

        public Cat GetByCui(string CUI)
        {
            EnsureLoaded();
            var cat = _cache.FirstOrDefault(c => c.Cui == CUI);
            if (cat == null) throw new KeyNotFoundException($"Cat with CUI '{CUI}' not found.");
            return cat;
        }

        public IEnumerable<Cat> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }

        public void RemoveFromRepo(Cat itemToRemove)
        {
            EnsureLoaded();
            _cache.Remove(itemToRemove);

            var dtoValues = new List<CatPercistenceDto>();
            for (int i = 0; i < _cache.Count; i++)
            {
                dtoValues.Add(_cache[i].ToDto());
            }

            var jsonString = JsonSerializer.Serialize(dtoValues);
            File.WriteAllText(_filePath, jsonString);
        }

        public void AddToRepo(Cat itemToAdd)
        {
            EnsureLoaded();
            _cache.Add(itemToAdd);

            var dtoValues = new List<CatPercistenceDto>();
            for (int i = 0; i < _cache.Count; i++)
            {
                dtoValues.Add(_cache[i].ToDto());
            }

            var jsonString = JsonSerializer.Serialize(dtoValues);
            File.WriteAllText(_filePath,jsonString);
        }

        public void Update(Cat itemToUpdate)
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
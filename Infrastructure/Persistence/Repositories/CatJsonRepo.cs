using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CatJsonRepo : ICatRepo
    {
        private List<Cat> _cache;
        private string _filePath = "cats.json";
        private void EnsureLoaded()
        {
            if (_cache.Count > 0) return;
            if (!File.Exists(_filePath))
            {
                _cache = new List<Cat>();
                return;
            }
            List<CatDto> dtoList = new List<CatDto>();
            dtoList = JsonSerializer.Deserialize<List<CatDto>>(File.ReadAllText(_filePath));
            for (int i = 0; i < dtoList.Count; i++)
            {
                _cache.Add(dtoList[i].ToEntity());
            }
        }

        public Cat? GetByCui(string CUI)
        {
            EnsureLoaded();
            for(int i = 0; i < _cache.Count; i++)
            {
                if (_cache[i].Cui == CUI) return _cache[i];
            }
            return null;
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
            List<CatDto> _dtovalues = new List<CatDto>();
            for (int i = 0; i < _cache.Count; i++)//trafrormo la lista di domain in lista di dto e la serializzo
            {
                _dtovalues.Add(_cache[i].ToDto());
            }
            string jsonString = JsonSerializer.Serialize(_dtovalues);
            File.WriteAllText(_filePath, jsonString);
        }
        public void AddToRepo(Cat itemToAdd)
        {
            EnsureLoaded();
            _cache.Add(itemToAdd);
            List<CatDto> _dtovalues = new List<CatDto>();
            for (int i = 0; i < _cache.Count; i++)
            {
                _dtovalues.Add(_cache[i].ToDto());
            }
            string jsonString = JsonSerializer.Serialize(_dtovalues);
            File.WriteAllText(_filePath, jsonString);
        }
        public void Update(Cat itemToUpdate)
        {
            EnsureLoaded();
            for(int i = 0; i < _cache.Count; i++)
            {
                if(_cache[i].Equals(itemToUpdate))
                {
                    _cache[i] = itemToUpdate;
                    break;
                }
            }

        }
    }
}

using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Mappers;
using Domain.Model.Entities;
using System.Text.Json;
using Infrastructure.Persistence.Dto;
namespace Infrastructure.Persistence.Repositories
{
    public class AdopterJsonRepo : IModelRepository<Adopter>
    {
        List<Adopter> _cache = new List<Adopter>();
        string _filePath="adopters.json";
        public AdopterJsonRepo()
        {
            EnsureLoaded();
        }
        public void EnsureLoaded()
        {
            if (_cache.Count > 0) return;
            if (!File.Exists(_filePath))
            {
                // file mancante -> cache vuota (già inizializzata)
                return;
            }
            _cache = JsonSerializer.Deserialize<List<AdopterPercistenceDto>>(File.ReadAllText(_filePath))!.Select(dto => dto.ToEntity()).ToList();
        }
        public void AddToRepo(Adopter itemToAdd)
        {
            EnsureLoaded();
            _cache.Add(itemToAdd);
            JsonSerializer.Serialize<List<AdopterPercistenceDto>>(_cache.Select(adopter => adopter.ToDto()).ToList());
        }

        public IEnumerable<Adopter> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }

        public void RemoveFromRepo(Adopter itemToRemove)
        {
            EnsureLoaded();
            _cache.Remove(itemToRemove);
            JsonSerializer.Serialize<List<AdopterPercistenceDto>>(_cache.Select(adopter => adopter.ToDto()).ToList());
        }

        public void Update(Adopter itemToUpdate)//DA RIVEDERE PER L'OVERRIDE DELL'EQUALS
        {
            EnsureLoaded();
            for(int i = 0; i < _cache.Count; i++)
            {
                if (_cache[i].HomeAddress == itemToUpdate.HomeAddress)
                {
                    _cache[i] = itemToUpdate;
                    break;
                }
            }
            JsonSerializer.Serialize<List<AdopterPercistenceDto>>(_cache.Select(adopter => adopter.ToDto()).ToList());
        }
    }
}

using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using System.Text.Json;
using Application.Dto;
using Application.Mappers;
namespace Infrastructure.Persistence.Repositories
{
    public class AdoptionJsonRepo : IAdoptionRepo
    {
        string filePath = "adoptions.json";
        private List<Adoption> _cache = new List<Adoption>();
        public void AddToRepo(Adoption itemToAdd)
        {
            EnsureLoaded();
            _cache.Add(itemToAdd);
            List<AdoptionDto> _dtovalues = new List<AdoptionDto>();
            for(int i=0;i<_cache.Count;i++)
            {
                _dtovalues.Add(_cache[i].ToDto());
            }
            string json= JsonSerializer.Serialize(_dtovalues);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Adoption> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }
        private void EnsureLoaded()
        {
            if(_cache.Count > 0) return;//controllo molto superficiale, andrebbe visto se fosse in un serve se sono stati fatti altri accessi al file json
            if (!File.Exists(filePath)) return;
            string json = File.ReadAllText(filePath);
            var dto = JsonSerializer.Deserialize<List<AdoptionDto>>(json);
            for(int i=0;i<dto.Count;i++)
            {
                _cache.Add(dto[i].ToEntity());
            }
        }
        public void RemoveFromRepo(Adoption itemToRemove)
        {
            EnsureLoaded();
            _cache.Remove(itemToRemove);
            List<AdoptionDto> _dtovalues = new List<AdoptionDto>();
            for (int i = 0; i < _cache.Count; i++)//trafrormo la lista di domain in lista di dto e la serializzo
            {
                _dtovalues.Add(_cache[i].ToDto());
            }
            string json = JsonSerializer.Serialize(_dtovalues);//cosí rimuovo l'elemento dal json sovrascrivenbdolo con la nuova lista
            File.WriteAllText(filePath, json);
        }

        public void Update(Adoption itemToUpdate)
        {
            EnsureLoaded();
            for(int i=0;i<_cache.Count;i++)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
using Application.Dto;
using Application.Mappers;
namespace Application.UseCases
{
    public class CatService
    {
        ICatRepo _catRepo;
        IAdoptionRepo _adoptionRepo;
        public CatService(ICatRepo catRepo, IAdoptionRepo adoptionRepo)
        {
            _catRepo = catRepo;
            _adoptionRepo = adoptionRepo;
        }
        public void AddCat(CatDto cat)
        {
            _catRepo.AddToRepo(cat.ToEntity());//ci potrebbe essere un controllo per evitare duplicati.
        }
        private void RemoveCat(CatDto cat)
        {
            _catRepo.RemoveFromRepo(cat.ToEntity());
        }
        public List<CatDto> GetAllCats()
        {
            return _catRepo.GetAll().Select(c => c.ToDto()).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
namespace Application.UseCases
{
    public class CatService
    {
        IModelRepository<Cat> _catRepo;
        IModelRepository<Adoption> _adoptionRepo;
        public CatService(IModelRepository<Cat> catRepo, IModelRepository<Adoption> adoptionRepo)
        {
            _catRepo = catRepo;
            _adoptionRepo = adoptionRepo;
        }
        public void AddCat(Cat cat)
        {
            _catRepo.AddToRepo(cat);//ci potrebbe essere un controllo per evitare duplicati.
        }
        private void RemoveCat(Cat cat)
        {
            _catRepo.RemoveFromRepo(cat);
        }
    }
}

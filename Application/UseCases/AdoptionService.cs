using Application.Interfaces;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Dto;
using Application.Mappers;
namespace Application.UseCases
{
    public class AdoptionService
    {
        IModelRepository<Cat> _catRepo;
        IModelRepository<Adoption> _adoptionRepo;
        /// <summary>
        ///
        /// </summary>
        /// <param name="catRepo"></param>
        /// <param name="adoptionRepo"></param>
        public AdoptionService(IModelRepository<Cat> catRepo, IModelRepository<Adoption> adoptionRepo)
        {
            _catRepo = catRepo;
            _adoptionRepo = adoptionRepo;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="cat"></param>
        /// <param name="adopter"></param>
        /// <param name="adoptionDate"></param>
        public void AdoptCat(CatDto cat, AdopterDto adopter, DateOnly adoptionDate)
        {
            cat.ToEntity().LeftCattery = adoptionDate;
            Adoption adoption = new Adoption(cat.ToEntity(), adopter.ToEntity(), adoptionDate);
            List<Adoption> adoptions = new List<Adoption>(_adoptionRepo.GetAll());
            _adoptionRepo.AddToRepo(adoption);
            RemoveCat(cat.ToEntity());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="cat"></param>
        private void RemoveCat(Cat cat)
        {
            _catRepo.RemoveFromRepo(cat);//da configurare sul repository in infrastructure
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="cat"></param>
        /// <param name="refundDate"></param>
        public void RefundCat(CatDto cat, DateOnly refundDate)
        {
            Cat obj = cat.ToEntity();
            //i need to  search for the cat  in  the adoptionList.
            Adoption adoption = SearchAdoptionByCat(cat);
            adoption.AdoptionCat.Description += $"Adoption Failed: Started on: {adoption.AdoptionDate} and ended on: {refundDate}";
            adoption.AdoptionCat.LeftCattery = null;
            _adoptionRepo.RemoveFromRepo(adoption);
            _catRepo.AddToRepo(obj);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private Adoption SearchAdoptionByCat(CatDto cat)
        {
            Cat obj = cat.ToEntity();
            List<Adoption> AllAdoptions = new List<Adoption>(_adoptionRepo.GetAll());
            for (int catPos = 0; catPos < AllAdoptions.Count(); catPos++)
            {
                if (obj == AllAdoptions[catPos].AdoptionCat)
                {
                    return AllAdoptions[catPos];
                }
            }
            throw new ArgumentException("Cat not found on the cattery list");
        }
    }
}

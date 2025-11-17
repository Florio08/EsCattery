using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IModelRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void RemoveFromRepo(T itemToRemove);
        public void AddToRepo(T itemToAdd);
        public void Update(T itemToUpdate);
    }
}

using Pets.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Repository
{
    public class OwnerRepository
    {

        private List<Owner> Owners = new List<Owner>();

        public OwnerRepository()
        {
            Owner owner1 = new Owner() { Id = 1, Name = "Adam Smith" };
            Owner owner2 = new Owner() { Id = 2, Name = "Scott Johnson" };
            Owner owner3 = new Owner() { Id = 3, Name = "Kimberly Parker" };
            

            Owners.Add(owner1);
            Owners.Add(owner2);
            Owners.Add(owner3);
            
        }


        public IEnumerable<Owner> GetAll()
        {
            return Owners;
        }

        public Owner GetById(long id)
        {
            return Owners.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}

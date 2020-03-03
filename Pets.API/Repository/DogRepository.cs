using Pets.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Repository
{
    public class DogRepository
    {

        private List<Dog> Dogs = new List<Dog>();

        public DogRepository()
        {
            Dog Dog1 = new Dog() { Id = 1, Name = "Maggie", Age = 1, OwnerId = 2 }; ;
            Dog Dog2 = new Dog() { Id = 2, Name = "Duke", Age = 7, OwnerId = 1 };
            Dog Dog3 = new Dog() { Id = 3, Name = "Buddy", Age = 4, OwnerId = 2 };

            Dogs.Add(Dog1);
            Dogs.Add(Dog2);
            Dogs.Add(Dog3);

        }

        public IEnumerable<Dog> GetAll()
        {
            return Dogs;
        }

        public Dog GetById(long id)
        {
            return Dogs.Where(p => p.Id == id).FirstOrDefault();
        }

        public Dog Save(Dog dog)
        {
            dog.Id = GenerateLastId();

            Dogs.Add(dog);

            return dog;

        }

        public Dog Edit(Dog dog)
        {
            var updateDog = Dogs.Where(p=> p.Id == dog.Id).FirstOrDefault();

            if (updateDog == null)
                return null;
            else
            {
                updateDog.Id = dog.Id;
                updateDog.Name = dog.Name;
                updateDog.Age = dog.Age;
                updateDog.OwnerId = dog.OwnerId;
            }

            return dog;

        }

        public Dog DeleteById(int id)
        {
            Dog deleteDog = Dogs.Where(p => p.Id == id).FirstOrDefault();

            if (deleteDog != null)
            {
                Dogs.Remove(deleteDog);
            }

            return deleteDog;
        }

        private int GenerateLastId()
        {
            var lastItem = Dogs.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastItem != null)
                return (lastItem.Id + 1);
            else
                return 1;
        }

    }
}

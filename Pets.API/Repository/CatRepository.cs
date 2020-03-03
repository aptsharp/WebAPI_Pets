using Pets.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Repository
{
    public class CatRepository
    {

        private List<Cat> Cats = new List<Cat>();

        public CatRepository()
        {
            Cat Cat1 = new Cat() { Id = 1, Name = "Lily", Age = 5, OwnerId = 1 };
            Cat Cat2 = new Cat() { Id = 2, Name = "Chloe", Age = 2, OwnerId = 3 };
            Cat Cat3 = new Cat() { Id = 3, Name = "Charlie", Age = 3, OwnerId = 2 };

            Cats.Add(Cat1);
            Cats.Add(Cat2);
            Cats.Add(Cat3);

            //Dados para pertinencia no banco
            
        }


        public IEnumerable<Cat> GetAll()
        {
            return Cats;
            //todos os gatos
        }

        public Cat GetById(long id)
        {
            return Cats.Where(p => p.Id == id).FirstOrDefault();
            //expressão lambda para pesquisa do banco de dados 
        }

        public Cat Save(Cat cat)
        {
            cat.Id = GenerateLastId();

            Cats.Add(cat);

            return cat;

            //salva um gato no banco de dados

        }

        public Cat Edit(Cat cat)
        {
            var updateCat = Cats.Where(p => p.Id == cat.Id).FirstOrDefault();

            if (updateCat == null)
                return null;
            else
            {
                updateCat.Id = cat.Id;
                updateCat.Name = cat.Name;
                updateCat.Age = cat.Age;
                updateCat.OwnerId = cat.OwnerId;
            }

            return cat;
            // classe de edição do banco de dados
        }

        public Cat DeleteById(int id)
        {
            Cat deleteCat = Cats.Where(p => p.Id == id).FirstOrDefault();

            if (deleteCat != null)
            {
                Cats.Remove(deleteCat);
                //se a pesquisa for diferente de null, excluir
            }

            return deleteCat;

            //deleta um gato
        }

        private int GenerateLastId()
        {
            var lastItem = Cats.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastItem != null)
            {
                return (lastItem.Id + 1);
            }
                
            else
                return 1;

            // ordena a lista de gatos
        }
    }
}

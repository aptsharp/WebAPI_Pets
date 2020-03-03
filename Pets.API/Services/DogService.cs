using Pets.API.Model;
using Pets.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Services
{
    public class DogService
    {

        private DogRepository _repository { get; }

        public DogService(DogRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Dog> GetAll()
        {
            IEnumerable<Dog> retorno = new List<Dog>();

            try
            {
                retorno = _repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public Dog GetById(int id)
        {

            Dog retorno = new Dog();

            try
            {
                retorno = _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }

        public Dog Save(Dog dog)
        {

            Dog retorno = new Dog();

            try
            {
                retorno = _repository.Save(dog);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }

        public Dog Edit(Dog dog)
        {

            Dog retorno = new Dog();

            try
            {
                retorno = _repository.Edit(dog);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }

        public Dog DeleteById(int id)
        {
            Dog retorno = new Dog();

            try
            {
                retorno = _repository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

    }
}

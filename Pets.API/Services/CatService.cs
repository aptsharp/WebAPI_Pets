using Pets.API.Model;
using Pets.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Services
{
    public class CatService
    {

        private CatRepository _repository { get; }

        public CatService(CatRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Cat> GetAll()
        {
            IEnumerable<Cat> retorno = new List<Cat>();

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

        public Cat GetById(long id)
        {

            Cat retorno = new Cat();

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

        public Cat Save(Cat cat)
        {

            Cat retorno = new Cat();

            try
            {
                retorno = _repository.Save(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }

        public Cat Edit(Cat cat)
        {

            Cat retorno = new Cat();

            try
            {
                retorno = _repository.Edit(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }

        public Cat DeleteById(int id)
        {
            Cat retorno = new Cat();

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

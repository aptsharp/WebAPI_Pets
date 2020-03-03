using Pets.API.Model;
using Pets.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Services
{
    public class OwnerService
    {

        private OwnerRepository _repository { get; }

        public OwnerService(OwnerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Owner> GetAll()
        {
            IEnumerable<Owner> retorno = new List<Owner>();

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

        public Owner GetById(long id)
        {

            Owner retorno = new Owner();

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

    }
}

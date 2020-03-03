using Microsoft.AspNetCore.Mvc;
using Pets.API.Model;
using Pets.API.Services;
using System.Collections.Generic;

namespace Pets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController
    {

        private OwnerService _service;

        public OwnerController(OwnerService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Owner> GetAll()
        {
            var retorno = (_service.GetAll());
            return retorno;

            // retorna todos os registros
        }

        [HttpPost("GetById")]
        public Owner GetById(long id)
        {
            var retorno = _service.GetById(id);
            return retorno;

            // retorna todos pelo Id / pesquisa por Id
        }

        /*
         * Regra de negocio é que este item seja apenas para exibição
         */

    }
}

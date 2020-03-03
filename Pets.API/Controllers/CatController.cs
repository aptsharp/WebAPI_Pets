using Microsoft.AspNetCore.Mvc;
using Pets.API.Model;
using Pets.API.Services;
using System.Collections.Generic;

namespace Pets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController
    {

        private CatService _service;

        public CatController(CatService service)
        {
            _service = service;
            
            // serviço do banco de dados
        }

        [HttpGet("GetAll")]
        public IEnumerable<Cat> GetAll()
        {
            var retorno = (_service.GetAll());
            return retorno;

            // para pegar todos os item do banco de dados
        }

        [HttpPost("GetById")]
        public Cat GetById(long id)
        {
            var retorno = _service.GetById(id);
            return retorno;

            // para mostrar um item pegando pelo id
        }

        [HttpPost("Save")]
        public Cat Save([FromBody] Cat cat)
        {

            var retorno = (_service.Save(cat));

            return retorno;

            // para salvar um gato / fazer um post
        }

        [HttpPost("Edit")]
        public Cat Edit([FromBody] Cat cat)
        {

            var retorno = (_service.Edit(cat));

            return retorno;

            // metodo para editar um gato
        }

        [HttpPost("DeleteById")]
        public Cat DeleteById(int id)
        {
            return _service.DeleteById(id);
        }

        // para deletar um gato pelo id

    }

    /*
     * regra de negocio permite um DRUD deste item 
     */
}

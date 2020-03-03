using Microsoft.AspNetCore.Mvc;
using Pets.API.Model;
using Pets.API.Services;
using System.Collections.Generic;

namespace Pets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController
    {

        private DogService _service;

        public DogController(DogService service)
        {
            _service = service;

            // serviço do banco de dados
        }

        [HttpGet("GetAll")]
        public IEnumerable<Dog> GetAll()
        {
            var retorno = (_service.GetAll());
            return retorno;

            // para pegar todos os item do banco de dados
        }

        [HttpPost("GetById")]
        public Dog GetById(int id)
        {
            var retorno = _service.GetById(id);
            return retorno;

            // para mostrar um item pegando pelo id
        }

        [HttpPost("Save")]
        public Dog Save([FromBody] Dog dog)
        {

            var retorno = (_service.Save(dog));

            return retorno;

            // para salvar um gato / fazer um post
        }

        [HttpPost("Edit")]
        public Dog Edit([FromBody] Dog dog)
        {

            var retorno = (_service.Edit(dog));

            return retorno;

            // metodo para editar um gato
        }

        [HttpPost("DeleteById")]
        public Dog DeleteById(int id)
        {
            return _service.DeleteById(id);
        }
        
        // para deletar um gato
    }

    /*
     * Regra de negocio permite um CRUD deste Item
     */
}

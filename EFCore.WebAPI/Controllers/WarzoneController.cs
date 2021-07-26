using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain.Models;
using EFCore.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarzoneController : ControllerBase
    {
        public readonly PersonagemContext _context;
        public WarzoneController(PersonagemContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filtro/{Name}")]
        public ActionResult GetPersonagemPorNome(string Name)
        {
            var listPersonagem = _context.Personagens.Where(x => x.Name.Equals(Name)).ToList(); //"LINQ METHODS"
            //var listPersonagem = (from personagem in _context.Personagens //LINQ QUERY
            //                      where personagem.Name.Contains(Name)
            //                      select personagem).ToList(); 


            return Ok(listPersonagem);

             
        }

        // GET api/values/5
        [HttpGet("atualizar/{nomePersonagem}/{nomenovo}")]
        public ActionResult<string> AtualizarPersonagem(string nomePersonagem, string nomenovo)
        {
            //var personagem = new Personagem { Name = nomePersonagem};
            var personagem = _context.Personagens.Where(x => x.Name == nomePersonagem).FirstOrDefault();
            personagem.Name = nomenovo;
                //_context.Personagens.Add(personagem);
            _context.SaveChanges();
                //contexto.Add(personagem);
            
            return Ok();
        }

        [HttpGet("add/{nomePersonagem}")]
        public ActionResult<string> AddPersonagem(string nomePersonagem)
        {
            var personagem = new Personagem { Name = nomePersonagem };
            _context.Add(personagem);
            _context.SaveChanges();

            return Ok();
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("deletar/{id}")] //GAMBIARRA SO PRA IR MAIS RAPIDO E DELETAR , PQ COM METODO DELETE N CONSIGO PASSA ELE NA ROTA
        public void Delete(int id)
        {
            var personagem = _context.Personagens.Where(x => x.Id == id).Single();
            _context.Personagens.Remove(personagem);
            _context.SaveChanges();
        }
    }
}

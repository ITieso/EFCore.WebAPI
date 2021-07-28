using EFCore.Domain.Models;
using EFCore.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapaController : ControllerBase
    {
        private readonly PersonagemContext _context;
        public MapaController(PersonagemContext context)
        {
            _context = context;
        }
        // GET: api/<PersonagemController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
             
                return Ok(new Mapa());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<PersonagemController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok( "value");
        }

        // POST api/<PersonagemController>
        [HttpPost]
        public ActionResult Post(Mapa model)
        {
            try
            {
              
                _context.Add(model);
                _context.SaveChanges();

                return Ok("Mapa Cadastrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<PersonagemController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Mapa mapa)  
        {
            try
            {
               if (_context.Personagens.AsNoTracking().FirstOrDefault(x => x.Id == id) != null)
                {
                     _context.Update(mapa);
                     _context.SaveChanges();
                         return Ok("Mapa Atualizado");
                }
                    return Ok("Nao Atualizou");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<PersonagemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

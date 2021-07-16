
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Arma 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Calibre { get; set; }
        public Personagem Personagem { get; set; }
        public int PersonagemId { get; set; }
    }
}

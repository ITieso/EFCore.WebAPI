using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skin> Skins { get; set; }
        public List<Arma> Armas { get; set; }
        public List<PersonagemMapa> PersonagemMapas { get; set; }
    }
}

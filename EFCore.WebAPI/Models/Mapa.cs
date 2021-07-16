using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Mapa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Terreno { get; set; }
        public int TempoDeGame { get; set; }
        public List<PersonagemMapa> PersonagemMapas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class PersonagemMapa
    {
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }

        public int MapaId{ get; set; }
        public Mapa Mapa { get; set; }
    }
}

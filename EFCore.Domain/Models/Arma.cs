
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Arma 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Personagem Personagem { get; set; }
    }
}

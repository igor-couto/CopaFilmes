using CopaDeFilmes.Domain.Interfaces;
using System.Collections.Generic;

namespace CopaDeFilmes.Domain.Entities
{
    public class Podium : IPodium
    {
        public List<IMovie> Finalists { get; set; }

        public IMovie Winner { get; set; }

        public IMovie SecondPlace { get; set; }

        public Podium() 
        {
            Finalists = new List<IMovie>();
        }
    }
}
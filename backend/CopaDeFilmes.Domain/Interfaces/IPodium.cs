using System.Collections.Generic;

namespace CopaDeFilmes.Domain.Interfaces
{
    public interface IPodium
    {
        List<IMovie> Finalists { get; }
        IMovie SecondPlace { get; }
        IMovie Winner { get; }
    }
}
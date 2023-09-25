using Back_End.DAL.Repositories.Generics;
using Back_End.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.Estilo
{
    public interface IEstiloRepository : IGenericInterface<EstiloDM>
    {
        IEnumerable<EstiloDM> GetAllEstilosWJoinedInfo();
        EstiloDM GetEstiloWJoinedInfo(int estiloDMId);
    }
}

using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.EstiloDMTallaDMRepository
{
    public interface IEstiloDMTallaDMRepository : IGenericInterface<EstiloDMTallaDM>
    {
        IEnumerable<EstiloDMTallaDM> GetEstilosTallasWJoinedInfo(int estiloDMId);
    }
}

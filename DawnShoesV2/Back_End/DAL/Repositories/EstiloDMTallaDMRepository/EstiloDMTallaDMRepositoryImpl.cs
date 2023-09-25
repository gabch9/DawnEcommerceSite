using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.EstiloDMTallaDMRepository
{
    public class EstiloDMTallaDMRepositoryImpl : GenericInterfaceImpl<EstiloDMTallaDM>, IEstiloDMTallaDMRepository
    {
        public EstiloDMTallaDMRepositoryImpl(DawnShoesModel context)
        : base(context)
        {
        }

        public IEnumerable<EstiloDMTallaDM> GetEstilosTallasWJoinedInfo(int estiloDMId)
        {
            return Context.EstiloDMTallaDM.Where(x => x.EstiloDMId == estiloDMId).Include(x => x.TallaDM);
        }
    }
}

using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.Estilo
{
    public class EstiloRepositoryImpl : GenericInterfaceImpl<EstiloDM>, IEstiloRepository
    {
        public EstiloRepositoryImpl(DawnShoesModel context)
        : base(context)
        { 
        }

        //Obtener toda la informacion unida del estilo. Agrega la descripcion del color entre otros datos
        public IEnumerable<EstiloDM> GetAllEstilosWJoinedInfo()
        {
            try
            {
                return Context.EstiloDM.Include(x => x.ColorDM).Include(x => x.GeneroDM).Include(x => x.EdadDM).Include(x => x.ClasificacionZapatoDM)
                .OrderBy(x => x.EstiloDMId).ToList();
            }
            catch (Exception err)
            {
                return null;
            }
            
        }

        //Consigue el joined info de un solo estilo para mostrarlo en los detalles
        public EstiloDM GetEstiloWJoinedInfo(int estiloDMId)
        {
            return Context.EstiloDM.Include(x => x.ColorDM).
                Include(x => x.GeneroDM).
                Include(x => x.EdadDM).
                Include(x => x.ClasificacionZapatoDM).
                Where(x => x.EstiloDMId == estiloDMId).SingleOrDefault();
        }
    }
}

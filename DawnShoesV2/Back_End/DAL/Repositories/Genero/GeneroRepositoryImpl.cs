using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.Genero
{
    public class GeneroRepositoryImpl : GenericInterfaceImpl<GeneroDM>, IGeneroRepository
    {
        public GeneroRepositoryImpl(DawnShoesModel context) : base(context)
        {

        }
    }
}

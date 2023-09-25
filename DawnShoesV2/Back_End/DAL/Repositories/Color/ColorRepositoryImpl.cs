using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.Color
{
    public class ColorRepositoryImpl : GenericInterfaceImpl<ColorDM>, IColorRepository
    {
        public ColorRepositoryImpl(DawnShoesModel context)
        : base(context)
        {
        }
    }
}

using Back_End.DAL.Models;
using Back_End.DAL.Repositories.ClasificacionZapato;
using Back_End.DAL.Repositories.Color;
using Back_End.DAL.Repositories.Edad;
using Back_End.DAL.Repositories.Estilo;
using Back_End.DAL.Repositories.Generics;
using Back_End.DAL.Repositories.Genero;
using Back_End.DAL.Repositories.EstiloDMTallaDMRepository;
using Back_End.DAL.Repositories.Talla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back_End.DAL.Repositories.ImagenEstilo;

namespace Back_End.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly DawnShoesModel context;
        
        //Variables de repositorios para inicializar en el constructor
        public IClasificacionZapatoRepository ClasificacionZapatoRepository { get; private set; }
        public IColorRepository ColorRepository { get; private set; }
        public IEdadRepository EdadRepository { get; private set; }
        public IEstiloRepository EstiloRepository { get; private set; }
        public IGeneroRepository GeneroRepository { get; private set; }
        public IEstiloDMTallaDMRepository EstiloDMTallaDM { get; private set; }
        public ITallaRepository TallaRepository { get; private set; }
        public IImagenEstiloRepository ImagenEstiloRepository { get; private set; }

        public UnitOfWork(DawnShoesModel _context)
        {
            context = _context;

            //Se le pasa el contexto a los respositorios

            ClasificacionZapatoRepository = new ClasificacionZapatoRepositoryImpl(context);
            ColorRepository = new ColorRepositoryImpl(context);
            EdadRepository = new EdadRepositoryImpl(context);
            EstiloRepository = new EstiloRepositoryImpl(context);
            GeneroRepository = new GeneroRepositoryImpl(context);
            EstiloDMTallaDM = new EstiloDMTallaDMRepositoryImpl(context);
            TallaRepository = new TallaRepositoryImpl(context);
            ImagenEstiloRepository = new ImagenEstiloRepositoryImpl(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

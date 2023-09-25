using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    public class GeneroDM
    {
        //ID para el genero
        public int GeneroDMId { get; set; }

        //descripcion del genero. Se pueden agregar o modificar en caso de que se quiera agregar unisex u otros
        public string Descripcion { get; set; }
    }
}

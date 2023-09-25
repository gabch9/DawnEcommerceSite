using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    public class ImagenEstiloDM
    {
        //Id de la foto
        [Key]
        public int ImagenEstiloDMId { get; set; }

        //Id del estilo
        public int EstiloDMId { get; set; }

        //Ruta para la imagen donde se va a guardar
        public string Path { get; set; }

        //Booleano para saber si la foto es la principal
        public bool EsPrincipal { get; set; }
    }
}

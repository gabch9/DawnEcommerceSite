using Back_End.DAL.Models;
using Back_End.Services.EstiloServices;
using DawnShoesV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DawnShoesV2.Controllers.AdminControllers
{
    public class ColorController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        // GET: Color
        public ActionResult PagListaColoresAdm()
        {
            //Se crea el color para guardar la lista
            ColorViewModel colorViewModel = new ColorViewModel();
            colorViewModel.ListaColores = ColorViewModel.ConvertDMListToColorVMList(catalogoService.GetListaColores());
            return View(
                    colorViewModel
                );
        }

        public ActionResult PagEditarColorAdm(int colorDMId)
        {
            return View(
                    ColorViewModel.ConvertToColorVM(catalogoService.UoW.ColorRepository.GetById(colorDMId))
                );
        }

        public ActionResult PagCreacionColorAdm()
        {
            return View();
        }

        public void BorrarColor(int id)
        {
            
        }

        //POST methods
        [HttpPost]
        public ActionResult CrearColor(ColorViewModel color)
        {
            catalogoService.UoW.ColorRepository.Add(ColorViewModel.ConvertToColorDM(color));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaColoresAdm");
        }
        
        //Este metodo depiendo si el int viene nulo o no actualiza un color o crea uno nuevo
        //Al final devuelve un JSON para armar en una tabla
        public JsonResult GuardarColor(int? colorDMId, string descripcion)
        {
            //Se arma un colorDM con los datos que vienen del post
            ColorDM colorDM = new ColorDM();
            colorDM.Descripcion = descripcion;

            if (colorDMId != null)
            {
                //Si es diferente a null se actualiza           
                colorDM.ColorDMId = (int)colorDMId;

                //Se retorna el objeto obtenido en json
                return Json(catalogoService.GuardarColorYObtenerObjeto(colorDM), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Si no lo es ahy que crear uno nuevo
                return Json(catalogoService.GuardarColorYObtenerObjeto(colorDM), JsonRequestBehavior.AllowGet);
            }           
        }
    }
}
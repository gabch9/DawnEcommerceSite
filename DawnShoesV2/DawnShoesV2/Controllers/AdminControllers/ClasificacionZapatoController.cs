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
    public class ClasificacionZapatoController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        public ActionResult PagListaClasificacionZapatoAdm()
        {

            return View(
                    ClasificacionZapatoViewModel.ConvertDMListToColorVMList(catalogoService.GetListaClasificaciones())
                );
        }

        public ActionResult PagEditarClasificacionZapatoAdm(int clasificacionZapatoDMId)
        {
            return View(ClasificacionZapatoViewModel.ConvertToColorVM(
                    catalogoService.UoW.ClasificacionZapatoRepository.GetById(clasificacionZapatoDMId))
                );
        }

        public ActionResult PagCreacionClasificacionZapatoAdm()
        {
            return View();
        }

        public void BorrarClasificacionZapato(int id)
        {

        }

        //Mapear de VM a DM
        public ClasificacionZapatoDM ConvertToClasificacionZapatoDM(ClasificacionZapatoViewModel clasificacionZapatoVM)
        {
            //Objeto que se va a retornar
            ClasificacionZapatoDM clasificacionZapatoDM = new ClasificacionZapatoDM();

            clasificacionZapatoDM.Descripcion = clasificacionZapatoVM.Descripcion;

            return clasificacionZapatoDM;
        }

        //POST methods
        [HttpPost]
        public ActionResult CrearClasificacionZapato(ClasificacionZapatoViewModel clasificacionZapato)
        {
            catalogoService.UoW.ClasificacionZapatoRepository.Add(ConvertToClasificacionZapatoDM(clasificacionZapato));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaClasificacionZapatoAdm");
        }

        [HttpPost]
        public ActionResult EditarClasificacionZapato(ClasificacionZapatoViewModel clasificacionZapato)
        {
            catalogoService.UoW.ClasificacionZapatoRepository.Add(ConvertToClasificacionZapatoDM(clasificacionZapato));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaClasificacionZapatoAdm");
        }
    }
}
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
    public class EdadController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        // GET: Color
        public ActionResult PagListaEdadesAdm()
        {
            return View(
                    EdadViewModel.ConvertDMListToEdadVMList(catalogoService.GetListaEdades())
                );
        }

        public ActionResult PagEditarEdadAdm(int edadDMId)
        {
            return View(EdadViewModel.ConvertToEdadVM(
                    catalogoService.UoW.EdadRepository.GetById(edadDMId))
                );
        }

        public ActionResult PagCreacionEdadAdm()
        {
            return View();
        }

        public void BorrarEdad(int id)
        {

        }

        //Mapear de VM a DM
        public EdadDM ConvertToEdadDM(EdadViewModel edadVM)
        {
            //Objeto que se va a retornar
            EdadDM edadDM = new EdadDM();

            edadDM.Descripcion = edadVM.Descripcion;

            return edadDM;
        }

        //POST methods
        [HttpPost]
        public ActionResult CrearEdad(EdadViewModel edad)
        {
            catalogoService.UoW.EdadRepository.Add(ConvertToEdadDM(edad));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaEdadesAdm");
        }

        [HttpPost]
        public ActionResult EditarEdad(EdadViewModel edad)
        {
            catalogoService.UoW.EdadRepository.Add(ConvertToEdadDM(edad));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaEdadesAdm");
        }
    }
}
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
    public class GeneroController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        public ActionResult PagListaGeneroAdm()
        {
            IEnumerable<GeneroViewModel> listaGenero = GeneroViewModel.ConvertDMListToGeneroVMList(catalogoService.UoW.GeneroRepository.GetAll());
            return View(listaGenero);
        }

        public ActionResult PagEditarGeneroAdm(int clasificacionZapatoDMId)
        {
            return View();
        }

        public ActionResult PagCreacionGeneroAdm()
        {
            return View();
        }

        public void BorrarGenero(int id)
        {

        }

        //POST methods
        [HttpPost]
        public ActionResult CrearGenero(GeneroViewModel genero)
        {
            catalogoService.UoW.GeneroRepository.Add(GeneroViewModel.ConvertToGeneroDM(genero));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaGeneroAdm");
        }

        [HttpPost]
        public ActionResult EditarGenero(GeneroViewModel genero)
        {
            catalogoService.UoW.GeneroRepository.Add(GeneroViewModel.ConvertToGeneroDM(genero));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaGeneroAdm");
        }
    }
}
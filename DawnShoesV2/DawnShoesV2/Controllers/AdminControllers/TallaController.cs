using Back_End.Services.EstiloServices;
using DawnShoesV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DawnShoesV2.Controllers.AdminControllers
{
    public class TallaController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        // GET: Color
        public ActionResult PagListaTallasAdm()
        {
            return View(
                    TallaViewModel.ConvertDMListToTallaVMList(catalogoService.GetListaTallas())
                );
        }

        public ActionResult PagEditarTallaAdm(int tallaDMId)
        {
            return View(
                    TallaViewModel.ConvertToTallaVM(catalogoService.UoW.TallaRepository.GetById(tallaDMId))
                );
        }

        public ActionResult PagCreacionTallaAdm()
        {
            return View();
        }

        public void BorrarColor(int id)
        {

        }

        //POST methods
        [HttpPost]
        public ActionResult CrearTalla(TallaViewModel talla)
        {
            catalogoService.UoW.TallaRepository.Add(TallaViewModel.ConvertToTallaDM(talla));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaTallasAdm");
        }

        [HttpPost]
        public ActionResult EditarTalla(TallaViewModel talla)
        {
            catalogoService.UoW.TallaRepository.Add(TallaViewModel.ConvertToTallaDM(talla));
            catalogoService.UoW.Complete();

            return RedirectToAction("PagListaTallasAdm");
        }
    }
}
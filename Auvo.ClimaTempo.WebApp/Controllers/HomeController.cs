using Auvo.ClimaTempo.WebApp.Models;
using Auvo.ClimaTempo.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auvo.ClimaTempo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController()
        {
            _context = new DatabaseContext();
        }
      
        public ActionResult Index()
        {
            // DateTime.Now.ToString("HH:mm:ss")
            var listaPrev = _context.PrevisaoClima.ToList();
            var listaMenores = _context.PrevisaoClima.OrderBy(x => x.TemperaturaMinima).Where(x => x.DataPrevisao == DateTime.Today).ToList();
            var listaMaiores = listaMenores.ToList();
            listaMaiores.Reverse();
            List<PrevisaoClima> listaTemp1 = new List<PrevisaoClima>();
            List<PrevisaoClima> listaTemp2 = new List<PrevisaoClima>();
            
            for (int i = 0; i < 3; i++)
            {
                listaTemp1.Add(listaMaiores[i]);
                listaTemp2.Add(listaMenores[i]);
            }

            ViewBag.PrevisoesHoje = _context.PrevisaoClima.Where(x => x.DataPrevisao == DateTime.Today).ToList();
            ViewBag.TemperaturasMaximas = listaTemp1;
            ViewBag.TemperaturasMinimas = listaTemp2;

            // dynamic models = new ExpandoObject(); <-- poderia ser usado no lugar de multilos viewbags
            ViewBag.Cidades = _context.Cidade.ToList();
            ViewBag.Estados = _context.Estado.ToList();
            var viewModel = new PrevisaoClimaViewModel();

            return View("Index", viewModel);
        }

        [AllowAnonymous]
        public ActionResult ListarCidade(string nome)
        {
            var lista = new List<PrevisaoClima>();
            var listaAtuais = new List<PrevisaoClima>();

            try
            {
                lista = _context.PrevisaoClima.Where(m => m.Cidade.Nome == nome).ToList();
                listaAtuais = _context.PrevisaoClima.Where(m => m.Cidade.Nome == nome).Where(m => m.DataPrevisao >= DateTime.Today).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(listaAtuais, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sobre()
        {
            return View();
        }
    }
}

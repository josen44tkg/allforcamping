using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alforcampingv2.Models;

namespace alforcampingv2.Controllers
{
    public class HomeController : Controller
    {
        private allforcampingEntities db = new allforcampingEntities();
        public ActionResult Index()
        {
            productosAleatorios();
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void productosAleatorios( )
        {
            var queryprod = from p in db.productos select p;
            var prod = queryprod.ToList();
            int aux=1;
            while (prod.Count < aux || aux > 6)
            {
                prod.RemoveAt(aux);
                aux++;

            }
            ViewBag.prodg = prod; 
        }

        private void ObtenerCategorias()
        {
            //Obtener todas las categorías
            var categoriasQuery = from c in db.categorias
                                  select c;
            var categorias = categoriasQuery.ToList();
            ViewBag.categorias = categorias;
        }

        public ActionResult Catalogo()
        {
            Session["lstLlantas"] = new List<productos>();
            Session["typeOrden"] = 1; //Por defecto el orden es alfabético
            Session["filtroCategoria"] = new List<string>();
            ObtenerCatalogo();
            return View();
        }

        public void ObtenerCatalogo()
        {
            var queryprod = from p in db.productos select p;
            var prod = queryprod.ToList();
            ViewBag.prods = prod;
          
        }
        public ActionResult Agregar(int a)
        {
            return RedirectToAction("Agregar","Carro", new { id = a });


        }
    }
}
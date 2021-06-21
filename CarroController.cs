using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alforcampingv2.Models;

namespace alforcampingv2.Controllers
{
    public class CarroController : Controller
    {
        private allforcampingEntities db = new allforcampingEntities();
        public ActionResult Index()
        {

            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Agregar(int id)
        {

            productos prod = new productos();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                productos l = db.productos.Find(id);
                
                cart.Add(new Item { productos = l, cantidad = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].cantidad++;
                }
                else
                {
                    productos l = db.productos.Find(id);
                   
                    cart.Add(new Item { productos = db.productos.Find(id), cantidad = 1 });
                }
                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> carro = (List<Item>)Session["cart"];
            for (int i = 0; i < carro.Count; i++)
                if (carro[i].productos.Id.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult quitar(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }

}
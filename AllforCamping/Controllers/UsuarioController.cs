using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alforcampingv2.Models;

namespace alforcampingv2.Controllers
{
    public class UsuarioController : Controller
    {
        private allforcampingEntities db = new allforcampingEntities();
        // GET: Usuario
        public ActionResult Index(string correo)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (db)
                {
                    var queryEmpleado = from st in db.usuarios
                                        where st.email == correo
                                        select st;
                    var listaEmpleado = queryEmpleado.ToList();
                    
                    if (listaEmpleado.Count > 0)
                    {
                        var clienteL = queryEmpleado.FirstOrDefault<usuarios>();
                        Session["id_ciente"] = clienteL.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    var querye = from st in db.empleados where st.email == correo select st;
                    var lista = queryEmpleado.ToList();
                    if (listaEmpleado.Count > 0)
                    {
                        var emp = querye.FirstOrDefault<empleados>();
                        Session["id_empleado"] = emp.Id;
                        return RedirectToAction("Index", "HomeEmpleados");
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
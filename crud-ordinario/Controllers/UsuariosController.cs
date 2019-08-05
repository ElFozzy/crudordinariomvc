using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud_ordinario.Models;

namespace crud_ordinario.Controllers
{
    public class UsuariosController : Controller
    {
        usuariosDAL usuariosDAL = new usuariosDAL();
        // GET: Usuarios
        public ActionResult Index()
        {
            List<usuarios> listUsuarios = new List<usuarios>();
            listUsuarios = usuariosDAL.ListarUsuarios().ToList();

            return View(listUsuarios);
        }

        public ActionResult Details(int id)
        {
            usuarios oUsuarios = usuariosDAL.ObtenerDatosUsuario(id);
            return View(oUsuarios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(usuarios oUsuarios)
        {
            if (ModelState.IsValid)
            {
                usuariosDAL.Agregarusuario(oUsuarios);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            usuarios oUsuarios = usuariosDAL.ObtenerDatosUsuario(id);
            return View(oUsuarios);
        }

        [HttpPost]
        public ActionResult Edit(int id, usuarios oUsuarios)
        {
            if (ModelState.IsValid)
            {
                usuariosDAL.ModificarUsuario(oUsuarios);
                return RedirectToAction("Index");
            }
            else
            {
                return View(oUsuarios);
            }
        }

        public ActionResult Delete(int id)
        {
            usuarios oEmpleado = usuariosDAL.ObtenerDatosUsuario(id);
            return View(oEmpleado);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                usuariosDAL.BorrarUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using PruebaLogin.DAO;
using PruebaLogin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaLogin.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
        UsuarioDAO usuarioDAO = null;
        UsuarioDTO usuarioDTO = null;
        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                usuariosDTO = usuarioDAO.Get();
                return View(usuariosDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();

            usuarioDTO = usuarioDAO.Get(ID);
            return View(usuarioDTO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
          
            

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioDTO usuarioDTO)
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.Create(usuarioDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();
            usuarioDTO = usuarioDAO.Edit(ID);
            return View(usuarioDTO);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int ID, UsuarioDTO usuarioDTO)
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.Edit(ID, usuarioDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();
            usuarioDTO = usuarioDAO.Delete(ID);
            return View(usuarioDTO);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            try
            {
                // TODO: Add delete logic here
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.Delete(ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

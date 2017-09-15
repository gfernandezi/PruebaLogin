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
                ModelState.Clear();
                usuariosDTO = usuarioDAO.GetAll();
                return View(usuariosDTO);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();
            ModelState.Clear();
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
                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    var rowsAffected = usuarioDAO.Create(usuarioDTO);
                    if (rowsAffected>0){
                        ViewBag.mensaje = "Usario creado satisfactoriamente.";
                        return RedirectToAction("Index");
                    }                   
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();
            ModelState.Clear();
            //usuarioDTO = usuarioDAO.Edit(ID);
            usuarioDTO = usuarioDAO.GetAll().Find(t => t.ID == ID);
            return View(usuarioDTO);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int ID, UsuarioDTO usuarioDTO)
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                ModelState.Clear();
                var rowsAffected = usuarioDAO.Edit(ID, usuarioDTO);              
                if (rowsAffected > 0){
                    return RedirectToAction("Index");
                }
                else{
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int ID)
        {
            usuarioDAO = new UsuarioDAO();
            usuarioDTO = new UsuarioDTO();
            ModelState.Clear();         
            usuarioDTO = usuarioDAO.Delete(ID);
            return View(usuarioDTO);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int? ID)
        {            
            try
            {                
                usuarioDAO = new UsuarioDAO();
                ModelState.Clear();
                if (usuarioDAO.Delete(ID)==1){
                    ViewBag.Mensaje = "Registro eliminado.";
                    return RedirectToAction("Index");
                }
                else{
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}

using Area.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Area.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var pessoa = new Pessoa
            {
                PessoaId = 1,
                Nome = "Hugo Vasconcelos",
                Tipo = "Administrador"
            };

            /*ViewBag
            ViewBag.PessoaId = pessoa.PessoaId;
            ViewBag.Nome = pessoa.Nome;
            ViewBag.Tipo = pessoa.Tipo;
            */

            /*ViewData*/
            ViewData["PessoaId"] = pessoa.PessoaId;
            ViewData["Nome"] = pessoa.Nome;
            ViewData["Tipo"] = pessoa.Tipo;

            //Model
            return View(pessoa);
            
            /*
            return View();
            */
        }

        public ActionResult Contatos()
        {
            return View();
        }

        //Forma 3
        [HttpPost]
        //[HttpGet]
        public ActionResult Lista(Pessoa pessoa)
        {
            return View(pessoa);
        }

        /* Forma 1 
        [HttpPost]
        public ActionResult Lista(int PessoaId, string Nome, string Tipo)
        {
            ViewData["PessoaId"] = PessoaId;
            ViewData["Nome"] = Nome;
            ViewData["Tipo"] = Tipo;

            return View();
        }
        

        //Forma 2
        [HttpPost]
        //[HttpGet]
        public ActionResult Lista(FormCollection form)
        {
            ViewData["PessoaId"] = form["PessoaId"];
            ViewData["Nome"] = form["Nome"];
            ViewData["Tipo"] = form["Tipo"];

            return View();
        }
        */
    }
}
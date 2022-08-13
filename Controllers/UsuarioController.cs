using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
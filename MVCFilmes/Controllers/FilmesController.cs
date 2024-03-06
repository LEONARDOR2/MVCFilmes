using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

using System;
using System.Threading;

namespace MVCFilmes.Controllers
{
    public class FilmesController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult BemVindo(string nome, int id)
        {
            ViewData["Title"] = "Bem vindos";

            ViewData["Nome"] = nome;
            ViewData["Numerox"] = id;


            return View();
        }




    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModuleControleColeta.Controllers
{
    public class SolicitacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InMemory.Models;
using InMemory.DAL;

namespace InMemory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(TestRepository.Listar());
        }

        public IActionResult ExcluirPrimeiro()
        {
            TestRepository.ExcluirPrimeiro();
            return RedirectToAction("Index");
        }
    }
}

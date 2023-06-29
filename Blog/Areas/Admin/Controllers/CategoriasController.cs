﻿using Blog.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _repoCategoria;

        public CategoriasController(ICategoriaRepositorio repoCategoria)
        {
            this._repoCategoria = repoCategoria;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
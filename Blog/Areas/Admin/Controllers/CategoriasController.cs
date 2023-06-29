using Blog.Models;
using Blog.Repositorio;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCategoria","Nombre","FechaCreacion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repoCategoria.CrearCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _repoCategoria.GetCategoria(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(int id, [Bind("IdCategoria","Nombre","FechaCreacion")] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repoCategoria.ActualizarCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        #region js 
        [HttpGet]
        public IActionResult GetCategorias()
        {
            return Json(new { data = _repoCategoria.GetCategorias() });
        }
        #endregion
    }
}

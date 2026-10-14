using BarberShopMvc.Models;
using BarberShopMvc.Services;
using BarberShopMvc.Services.Excptions;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopMvc.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        public IActionResult Index()
        {
            var list = _servicoService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _servicoService.Insert(servico);
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _servicoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Servico servico)
        {
            if (id != servico.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(servico);
            }
            try
            {
                _servicoService.Update(servico);
                return RedirectToAction(nameof(Index));
            }
            catch (DbConcurrencyException e)
            {
                return BadRequest();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var servico = _servicoService.FindById(id.Value);
            if(servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }
        public IActionResult Delete(int? id) { 
            if(id == null)
            {
                return NotFound();
            }
            var servico = _servicoService.FindById(id.Value);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _servicoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}

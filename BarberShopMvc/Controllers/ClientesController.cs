using BarberShopMvc.Data;
using Microsoft.AspNetCore.Mvc;
using BarberShopMvc.Models;
using BarberShopMvc.Services;
using BarberShopMvc.Services.Excptions;
namespace BarberShopMvc.Controllers

{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public IActionResult Index()
        {
            var list = _clienteService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Insert(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _clienteService.FindById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            try
            {
                _clienteService.Update(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {

                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _clienteService.FindById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteService.FindById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _clienteService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

        }

    }
}

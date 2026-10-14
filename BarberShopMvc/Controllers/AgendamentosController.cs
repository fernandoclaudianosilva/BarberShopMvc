using BarberShopMvc.Models;
using BarberShopMvc.Models.ViewModels;
using BarberShopMvc.Services;
using BarberShopMvc.Services.Excptions;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopMvc.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IServicoService _servicoService;
        private readonly IClienteService _clienteService;

        public AgendamentosController(IAgendamentoService agendamentoService,IServicoService servicoService,IClienteService clienteService)
        {
            _agendamentoService = agendamentoService;
            _clienteService = clienteService;
            _servicoService = servicoService;
        }


        public IActionResult Index()
        {
            var list = _agendamentoService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var viewModel = new AgendamentoFormViewModel
            {
                Clientes = _clienteService.FindAll().ToList(),
                Servicos = _servicoService.FindAll().ToList()
            };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Agendamento agendamento) {

            ModelState.Remove("Agendamento.Cliente");
            ModelState.Remove("Agendamento.Servico");
            if (!ModelState.IsValid)
            {
                var viewModel = new AgendamentoFormViewModel
                {
                    Agendamento = agendamento,
                    Clientes = _clienteService.FindAll().ToList(),
                    Servicos = _servicoService.FindAll()
                };
                return View(viewModel);
            }
            _agendamentoService.Insert(agendamento);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _agendamentoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var viewModel = new AgendamentoFormViewModel
            {
                Agendamento = obj,
                Clientes = _clienteService.FindAll().ToList(),
                Servicos = _servicoService.FindAll()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Agendamento agendamento) { 
            if(id != agendamento.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                var viewModel = new AgendamentoFormViewModel
                {
                    Agendamento = agendamento,
                    Clientes = _clienteService.FindAll().ToList(),
                    Servicos = _servicoService.FindAll()
                };
                return View(viewModel);
            }
            try
            {
                _agendamentoService.Update(agendamento);
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
            if(id == null)
            {
                return NotFound();
            }
            var agendamento = _agendamentoService.FindById(id.Value);
            if(agendamento == null)
            {
                return NotFound();
            }
            return View(agendamento);
        }
        public IActionResult Delete(int? id) { 
            if(id == null)
            {
                return NotFound();
            }
            var agendamento = _agendamentoService.FindById(id.Value);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _agendamentoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }  
}

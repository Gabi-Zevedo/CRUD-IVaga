using IVaga.Data;
using IVaga.Models;
using IVaga.Models.ViewModels;
using IVaga.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IVaga.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly VeiculoService _veiculoService;

        public VeiculosController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoService.FindAllAsync();
            return View(veiculos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculo);
            }
            await _veiculoService.InsertAsync(veiculo);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var veiculo = await _veiculoService.FindByIdAsync(id.Value);
            if(veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _veiculoService.FindByIdAsync(id.Value);
            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _veiculoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var veiculo = await _veiculoService.FindByIdAsync(id.Value);
            if(veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculo);
            }

            if(id != veiculo.Id)
            {
                return NotFound();
            }
            await _veiculoService.UpdateAsync(veiculo);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

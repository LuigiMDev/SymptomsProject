using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SymptomsProject.Data;
using SymptomsProject.Models;
using SymptomsProject.Models.ViewModels;
using SymptomsProject.Services;

namespace SymptomsProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientService _service;

        public PatientsController(PatientService service)
        {
            _service = service;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _service.FindAllAsync());
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new {message = ex.Message});
            }
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "É necessário passar um ID" });
                }
                Patient patient = await _service.FindByIdAsync(id.Value);
                if (patient == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "Paciente não encontrado" });
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(patient);
                }
                await _service.Create(patient);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "É necessário passar um ID" });
                }
                Patient patient = await _service.FindByIdAsync(id.Value);
                if (patient == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "Paciente não encontrado" });
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ocorreu um erro ao processar os IDs" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Edit(patient);
                }
                catch (DbUpdateConcurrencyException db)
                {
                    return RedirectToAction(nameof(Error), new { message = db.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

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
    public class SymptomsController : Controller
    {
        private readonly SymptomService _service;
        private readonly PatientService _patientService;

        public SymptomsController(SymptomService service, PatientService patientService)
        {
            _service = service;
            _patientService = patientService;
        }

        // GET: Symptoms
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _service.FindAllAsync());
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Symptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "É necessário passar um ID" });
                }

                Symptom symptom = await _service.FindByIdAsync(id.Value);
                if (symptom == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "Registro não encontrado" });
                }
                return View(symptom);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Symptoms/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                List<Patient> patients = await _patientService.FindAllAsync();
                SymptomCreateViewModel viewModel = new SymptomCreateViewModel { Patients = patients };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // POST: Symptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SymptomCreateViewModel viewModel)
        {
            try
            {
                viewModel.Symptom.Patient = await _patientService.FindByIdAsync(viewModel.PatientSelectedId);
                _service.Create(viewModel.Symptom); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Symptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "É necessário passar um ID" });
            }

            Symptom symptom = await _service.FindByIdAsync(id.Value);
            if (symptom == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Registro não encontrado" });
            }
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Symptom symptom)
        {
            if (id != symptom.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ocorreu um erro ao processar os IDs" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Edit(symptom);
                }
                catch (DbUpdateConcurrencyException db)
                {
                    return RedirectToAction(nameof(Error), new { message = db.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(symptom);
        }


        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

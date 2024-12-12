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
                if (viewModel.Symptom.Patient == null)
                {
                    ModelState.AddModelError(nameof(viewModel.PatientSelectedId), "Por favor, selecione um paciente válido.");
                }
                if (!ModelState.IsValid)
                {
                    viewModel.Patients = await _patientService.FindAllAsync();
                    return View(viewModel);
                }
                viewModel.Symptom.EditDate = DateTime.Now;
                viewModel.Symptom.CreationDate = DateTime.Now;
                await _service.Create(viewModel.Symptom); 
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
                List<Patient> patients = await _patientService.FindAllAsync();
                SymptomCreateViewModel viewModel = new SymptomCreateViewModel { Patients = patients, Symptom = symptom, PatientSelectedId = symptom.Patient.Id };
                return View(viewModel);
            }

            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }   
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SymptomCreateViewModel viewModel)
        {
            if (id != viewModel.Symptom.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ocorreu um erro ao processar os IDs" });
            }
            if (viewModel.Symptom.Patient == null)
            {
                ModelState.AddModelError(nameof(viewModel.PatientSelectedId), "Por favor, selecione um paciente válido.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.Symptom.EditDate = DateTime.Now;
                    await _service.Edit(viewModel.Symptom);
                }
                catch (DbUpdateConcurrencyException db)
                {
                    return RedirectToAction(nameof(Error), new { message = db.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            viewModel.Patients = await _patientService.FindAllAsync();
            return View(viewModel);
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

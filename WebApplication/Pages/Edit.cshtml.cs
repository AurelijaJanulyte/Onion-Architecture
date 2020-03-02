using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Model;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class EditModel : PageModel
    {
        private IWorkerService _workerService;
        [BindProperty]
        public Worker Worker { get; set; }

        public EditModel(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public async Task OnGet(int? id)
        {
            if (id.HasValue)
            {
                var worker = await _workerService.GetWorker(id.Value);
                Worker = new Worker
                {
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    PersonalCode = worker.PersonalCode,
                    Birthday = worker.Birthday,
                    HomeAddress = worker.HomeAddress
                };
            }
            else
            {
                Worker = new Worker();
            }
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            TempData["Message"] = "Worker was saved";

            if (id.HasValue)
            {
                await _workerService.UpdateWorker(id.Value, Worker);
            }
            else
            {
                if (!ModelState.IsValid)
                {
                   return Page();
                }

                await _workerService.CreateNewWorker(
                    Worker.FirstName, Worker.LastName, Worker.PersonalCode.Value, Worker.Birthday.Value, Worker.HomeAddress);
            }
            return RedirectToPage("/WorkersList");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class DeleteModel : PageModel
    {
        public Worker Worker { get; set; }
        private IWorkerService _workerService;

        public DeleteModel(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        public async Task OnGet(int id)
        {
            var worker = await _workerService.GetWorker(id);
            Worker = new Worker
            {
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                PersonalCode = worker.PersonalCode,
                Birthday = worker.Birthday,
                HomeAddress = worker.HomeAddress
            };
        }

        public async Task<IActionResult> OnPost(int id) 
        {
            var worker = await _workerService.GetWorker(id);

            if (worker != null) 
            {
                await _workerService.DeleteWorker(id);
            }

            TempData["Message"] = $"{worker.FirstName} {worker.LastName} deleted";
            return RedirectToPage("/WorkersList");
        }
    }
}

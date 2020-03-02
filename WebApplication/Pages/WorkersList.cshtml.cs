using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class WorkersListModel : PageModel
    {
        private readonly IWorkerService _workerService;

        public IEnumerable<WorkerInfo> WorkersList { get; set; }

        public WorkersListModel(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public async Task OnGet()
        {
             WorkersList = await _workerService.GetAllWorkers();
        }
    }
}

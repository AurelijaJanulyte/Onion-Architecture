using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Pages
{
    public class WorkersListModel : PageModel
    {
        private readonly IWorkerService _workerService;
        private readonly IHtmlHelper _htmlHelper;

        public IEnumerable<WorkerInfo> WorkersList { get; set; }

        [BindProperty(SupportsGet = true)]
        public FilterOptions SelectedOption { get; set; }

        public IEnumerable<SelectListItem> Filter { get; set; }

        public WorkersListModel(IWorkerService workerService,
             IHtmlHelper htmlHelper)
        {
            _workerService = workerService;
            _htmlHelper = htmlHelper;
            Filter = htmlHelper.GetEnumSelectList<FilterOptions>();
        }

        public async Task OnGet()
        {
             WorkersList = await _workerService.GetAllWorkers(SelectedOption);
        }
    }
}

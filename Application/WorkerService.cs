using Application.Model;
using Domain.Entites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class WorkerService : IWorkerService
    {
        private WorkersContext _context;

        public WorkerService(WorkersContext context)
        {
            _context = context;
        }

        public async Task CreateNewWorker(string firstName, string lastName, int personalCode, DateTime birthDay, string address)
        {
            await _context.AddAsync(new WorkerInfo(firstName, lastName, personalCode, birthDay, address));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorker(int id, Worker model)
        {
            var worker = await _context.WorkersList.SingleAsync(w => w.Id == id);

            if (!string.IsNullOrEmpty(model.FirstName))
            {
                worker.FirstName = model.FirstName;
            }

            if (!string.IsNullOrEmpty(model.LastName))
            {
                worker.LastName = model.LastName;
            }

            if (model.PersonalCode.HasValue)
            {
                worker.PersonalCode = model.PersonalCode.Value;
            }

            if (model.Birthday.HasValue)
            {
                worker.Birthday = model.Birthday.Value;
            }

            if (!string.IsNullOrEmpty(worker.HomeAddress))
            {
                worker.HomeAddress = model.HomeAddress;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkerInfo>> GetAllWorkers()
        {
            var workers = await _context.WorkersList.Where(w => w.WorkerStatus == Status.Active).ToListAsync();
            return workers;
        }

        public async Task<WorkerInfo> GetWorker(int id)
        {
            var worker = await _context.WorkersList.SingleAsync(w => w.Id == id);
            return worker;
        }

        public async Task DeleteWorker(int id)
        {
            var worker = await _context.WorkersList.SingleAsync(w => w.Id == id);
            worker.WorkerStatus = Status.Inactive;
            await _context.SaveChangesAsync();
        }
    }
}

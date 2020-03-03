using Application.Model;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IWorkerService
    {
        Task CreateNewWorker(string firstName, string lastName, int personalCode, DateTime birthDay, string address);
        Task DeleteWorker(int id);
        Task<IEnumerable<WorkerInfo>> GetAllWorkers(FilterOptions filter);
        Task<WorkerInfo> GetWorker(int id);
        Task UpdateWorker(int id, Worker model);
    }
}
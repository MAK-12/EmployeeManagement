﻿using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public interface IWorkItemService
    {
        Task<IEnumerable<WorkItem>> GetWorkItems();
        Task<WorkItem> CreateWorkItem(WorkItem emp);
        Task<WorkItem> UpdateWorkItem(WorkItem emp);
        Task<bool> DeleteWorkItem(int id);
        Task<WorkItem> GetWorkItemById(int id);
    }
}

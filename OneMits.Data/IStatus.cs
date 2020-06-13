using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IStatus
    {
        Status GetById(int id);
        IEnumerable<Status> GetAll();
        IEnumerable<Status> GetFilteredStatus(string searchQuery);
        IEnumerable<Status> GetLatestStatus(int n);
        

        Task AddStatus(Status status);
        Task Delete(int Statusid);
        Task EditStatusContent(int id, string newContent);
    }
}

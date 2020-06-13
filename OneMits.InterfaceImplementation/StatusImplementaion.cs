using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class StatusImplementation : IStatus
    {
        private readonly ApplicationDbContext _context;

        public StatusImplementation(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int Statusid)
        {
            throw new NotImplementedException();
        }

        public Status GetById(int id)
        {
            return _context.Status.Where(status => status.StatusId == id)
               .Include(status => status.User)
               .First();
        }
        public Task EditStatusContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status
                .Include(status => status.StatusCategory)
                 .Include(status => status.User);
        }
        public IEnumerable<Status> GetFilteredStatus(int id)
        {
            return _context.Status.Where(Statusid => Statusid.StatusCategory.StatusCategoryId == id)
                .Include(status => status.User)
                .Include(status => status.StatusCategory); ;
        }
        public IEnumerable<Status> GetFilteredStatus(string searchQuery)
        {
            return GetAll().Where(post => post.StatusTitle.Contains(searchQuery));
        }

        public IEnumerable<Status> GetLatestStatus(int n)
        {
            throw new NotImplementedException();
        }

        
    }
}

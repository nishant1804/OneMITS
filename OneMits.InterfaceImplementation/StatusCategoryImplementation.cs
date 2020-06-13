using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
 using System.Threading.Tasks;
using System.Linq;

namespace OneMits.InterfaceImplementation
{
    public class StatusCategoryImplementation : IStatusCategory
    {
        private readonly ApplicationDbContext _context;

        public StatusCategoryImplementation(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateModel(StatusCategory statuscategory)
        {
            _context.Add(statuscategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int statuscategoryid)
        {
            var category = GetById(statuscategoryid);
            _context.RemoveRange(category.Status);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }


        public IEnumerable<StatusCategory> GetAll()
        {
            return _context.StatusCategories
                .Include(statuscategory => statuscategory.Status);
       
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public StatusCategory GetById(int id)
        {
            var category = _context.StatusCategories.Where(c => c.StatusCategoryId == id)
                .Include(f => f.Status)
                .ThenInclude(p => p.User)
                .FirstOrDefault();
            return category; ;
        }

        public IEnumerable<StatusCategory> GetAllDropDown()
        {
            return _context.StatusCategories
                .Include(s => s.StatusCategoryId)
                .Include(status => status.StatusCategoryTitle);
        }

        public IEnumerable<StatusCategory> GetFilteredStatusCategory()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusCategoryTitle(int statuscategoryid, string newStatusCategoryTitle)
        {
            throw new NotImplementedException();
        }
    }
}

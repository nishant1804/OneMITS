using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IStatusCategory
    {
        StatusCategory GetById(int id);
        IEnumerable<StatusCategory> GetAll();
        IEnumerable<StatusCategory> GetFilteredStatusCategory();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        IEnumerable<StatusCategory> GetAllDropDown();
        Task CreateModel(StatusCategory statuscategory);
        Task Delete(int statuscategoryid);
        Task UpdateStatusCategoryTitle(int statuscategoryid, string newStatusCategoryTitle);
    }
}

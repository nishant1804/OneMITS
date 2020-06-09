using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        string GetByRequestId(ConnectingList connectingList);
        ApplicationUser GetByUserName(string userName);
        IEnumerable<ApplicationUser> GetSearchUserName(string userName);
        IEnumerable<ApplicationUser> GetAll();
        IEnumerable<ConnectingList> GetAllRequest();
        OtpTable GetByEnrollment(string EnrollmentNumber);
        TeacherTable GetByTeacherEnrollment(string EnrollmentNumber);
        IEnumerable<OtpTable> GetAllStudents();

        Task UpdateUserRating(string id, Type type);
        Task SendRequest(ConnectingList connectModel);
        Task AcceptRequest(ConnectedList connectModel);
        Task DeleteRequest(ConnectingList connectModel);
        Task AddLoginTime(LoginTime loginTime);
        Task AddVisit(Visits visits);
        Task Delete(string id);
        Task UnDelete(string id);
    }
}

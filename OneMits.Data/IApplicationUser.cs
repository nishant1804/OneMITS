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
        string GetByAcceptId(ConnectedList connectingList);
        ApplicationUser GetByUserName(string userName);
        IEnumerable<ApplicationUser> GetSearchUserName(string userName);
        IEnumerable<ApplicationUser> GetAll();
        IEnumerable<ConnectingList> GetAllRequest();
        IEnumerable<Notification> GetNotifications(ApplicationUser applicationUser);
        OtpTable GetByEnrollment(string EnrollmentNumber);
        TeacherTable GetByTeacherEnrollment(string EnrollmentNumber);
        IEnumerable<OtpTable> GetAllStudents();

        Task UpdateUserRating(string id, Type type);
        Task SendRequest(ConnectingList connectModel);
        Task UnFriend(ConnectingList connectingList);
        Task AcceptRequest(ConnectingList connectModel);
        Task DeleteRequest(ConnectingList connectModel);
        Task DenyRequest(ConnectingList connectModel);
        Task AddLoginTime(LoginTime loginTime);
        Task AddVisit(Visits visits);
        Task Delete(string id);
        Task UnDelete(string id);
        Task AddNotification(Notification notification);
        Task AddNotificationCount(ApplicationUser applicationUser);
        Task MarkRead(ApplicationUser applicationUser); 
    }
}

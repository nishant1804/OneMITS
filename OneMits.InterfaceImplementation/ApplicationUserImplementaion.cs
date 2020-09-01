using Microsoft.EntityFrameworkCore;
using EtherealMade.Data;
using EtherealMade.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMade.InterfaceImplementation
{
    public class ApplicationUserImplementation : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }
        public IEnumerable<ConnectingList> GetAllRequest()
        {
            return _context.ConnectingList

                   .Include(request => request.Sender)
                   .Include(request => request.Receiver);
                  
        }
        public IEnumerable<ConnectedList> GetAllConnectedRequest()
        {
            return _context.ConnectedList
                   .Include(request => request.Id)
                   .Include(request => request.User1)
                   .Include(request => request.User2);
        }
        
        
        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }
        public string GetByRequestId(ConnectingList connectingList)
        {

            var temp1 = GetRequest(connectingList);
            var xtmp = connectingList.Receiver;
            connectingList.Receiver = connectingList.Sender;
            connectingList.Sender = xtmp;
            var tmp1 = GetRequest(connectingList);
            if (temp1 == null && tmp1 == null)
            {
                return "connect";
            }
            if (temp1 != null)
            {
                if (temp1.Status == "friends") {
                    return "connected";
                }
            }
            if (tmp1 != null)
            {
                if (tmp1.Status == "friends")
                {
                    return "connected";
                }
            }
            if (temp1 != null)
            {
                if (temp1.Status == "pending")
                {
                    return "sent";
                }
            }
            if (tmp1 != null)
            {
                if (tmp1.Status == "pending")
                {
                    return "received";
                }
            }
            
            
            return ".";
        }
        public async Task UnFriend(ConnectingList connectingList)
        {
            var temp1 = GetConnected(connectingList);
            var xtmp = connectingList.Receiver;
            connectingList.Receiver = connectingList.Sender;
            connectingList.Sender = xtmp;
            var tmp1 = GetConnected(connectingList);
            if(temp1 != null)
            {
                temp1.Status = "cancel";
                await _context.SaveChangesAsync();
            }
            if(tmp1 != null)
            {
                tmp1.Status = "cancel";
                await _context.SaveChangesAsync();
            }
        }
      
        public async Task DeleteRequest(ConnectingList connectingList)
        {
            var temp1 = GetPending(connectingList);
            temp1.Status = "cancel";
            await _context.SaveChangesAsync();
        }
        public async Task DenyRequest(ConnectingList connectingList)
        {
            
            var temp1 = GetPending(connectingList);
            temp1.Status = "cancel";
            
            await _context.SaveChangesAsync();
        }
        public async Task AcceptRequest(ConnectingList connectingList)
        {
            
            var temp1 = GetPending(connectingList);
            temp1.Status = "friends"; 
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Notification> GetNotifications(ApplicationUser applicationUser)
        {
            return _context.Notification.Where(userto => userto.UserTo == applicationUser)
                                        .OrderByDescending(date => date.DateTime)
                                        .Include(user => user.UserFrom)
                                        .Include(user => user.UserFrom);
        }
        public ConnectingList GetAccept(ConnectingList connectingList)
        {
            return _context.ConnectingList.Where(user1 => user1.Sender == connectingList.Sender && user1.Receiver == connectingList.Receiver && user1.Status == "pending")
                  .Include(request => request.Sender)
                   .Include(request => request.Receiver)
                   .FirstOrDefault();
        }
        public ConnectingList GetPending(ConnectingList connectingList)
        {
            return _context.ConnectingList.Where(user1 => user1.Sender == connectingList.Sender && user1.Receiver == connectingList.Receiver && user1.Status == "pending")
               .Include(request => request.Sender)
                   .Include(request => request.Receiver)
                   .FirstOrDefault();
        }
        public ConnectingList GetConnected(ConnectingList connectingList)
        {
            return _context.ConnectingList.Where(user1 => user1.Sender == connectingList.Sender && user1.Receiver == connectingList.Receiver && user1.Status == "friends")
                   .Include(request => request.Sender)
                   .Include(request => request.Receiver)
                   .FirstOrDefault();
        }
        public ConnectingList GetRequest(ConnectingList connectingList)
        {
            return _context.ConnectingList.Where(user1 => user1.Sender == connectingList.Sender && user1.Receiver == connectingList.Receiver && user1.Status != "cancel")
                   .Include(request => request.Sender)
                   .Include(request => request.Receiver)
                   .FirstOrDefault();
        }
        public string GetByAcceptId(ConnectedList connectedList)
        {
            var temp1 = GetConnectedRequest(connectedList);
            var xtmp = connectedList.User2;
            connectedList.User2 = connectedList.User1;
            connectedList.User1 = xtmp;
            var tmp1 = GetConnectedRequest(connectedList);
            if (temp1 == null && tmp1 == null)
            {
                return "connect";
            }
            if (temp1 != null || tmp1 !=null)
            {
                return "friends";
            }

            return ".";

        }
        public ConnectedList GetConnectedRequest(ConnectedList connectingList)
        {
            return _context.ConnectedList.Where(user1 => user1.User1 == connectingList.User1 && user1.User2 == connectingList.User2)
                   .Include(request => request.Id)
                   .Include(request => request.User1)
                   .Include(request => request.User2)
                   .First();
        }
        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            user.Rating = CalculateUserRating(type, user.Rating);
            await _context.SaveChangesAsync();
        }
        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;
            if (type == typeof(Question))
                inc = 2;
            if (type == typeof(Answer))
                inc = 5;
            return userRating + inc;
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<ApplicationUser> GetAllUser()
        {
            return _context.ApplicationUsers
                .Include(user => user.Id);
        }
        public async Task Delete(string id)
        {
            var user = GetById(id);
            user.IsActive = true;
            await _context.SaveChangesAsync();
        }
        public async Task UnDelete(string id)
        {
            var user = GetById(id);
            user.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public ApplicationUser GetForId(string id)
        {
            var user = _context.ApplicationUsers.Where(c => c.Id == id)
                .Include(f => f.Id)
                .FirstOrDefault();
            return user;
        }

        public async Task AddLoginTime(LoginTime loginTime)
        {
            _context.LoginTime.Add(loginTime);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<OtpTable> GetAllStudents()
        {
            return _context.OtpTable;
        }
        public IEnumerable<TeacherTable> GetAllTeachers()
        {
            return _context.TeacherTable;
        }

        public OtpTable GetByEnrollment(string enrollmentNumber)
        {
            return GetAllStudents().FirstOrDefault(student => student.EnrollmentNumber == enrollmentNumber);
        }

        public ApplicationUser GetByUserName(string userName)
        {
            return GetAll().FirstOrDefault(user => user.UserName == userName);
        }

        public IEnumerable<ApplicationUser> GetSearchUserName(string searchQuery)
        {
            return GetAll().Where(post => post.UserName.Contains(searchQuery));
        }
        public async Task AddVisit(Visits visits)
        {
            _context.Visits.Add(visits);
            await _context.SaveChangesAsync();
        }

        public TeacherTable GetByTeacherEnrollment(string enrollmentNumber)
        {
            return GetAllTeachers().FirstOrDefault(teacher => teacher.EnrollmentNumber == enrollmentNumber);
        }

        public async Task SendRequest(ConnectingList connectModel)
        {
            var temp = new ConnectingList
            {
                Sender = connectModel.Sender,
                Receiver = connectModel.Receiver,
                Status = "pending"
            };
            _context.ConnectingList.Add(temp);
            await _context.SaveChangesAsync();
        }

        public async Task AddNotification(Notification notification)
        {
           // var tmp = notification.UserTo;
            //tmp.UnreadNotification += 1;
            _context.Notification.Add(notification); 
            await _context.SaveChangesAsync();
        }
        public async Task AddNotificationCount(ApplicationUser applicationUser)
        {
            //var user = applicationUser;
           // applicationUser.UnreadNotification = 0;
            await _context.SaveChangesAsync();
        }

        public async Task MarkRead(ApplicationUser applicationUser)
        {
            var tmp = GetNotifications(applicationUser).Where(tmp11 => tmp11.Status == false);
            foreach(var tmp1 in tmp)
            {
                tmp1.Status = true; 
            }
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
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
            return _context.ConnectingList;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }
        public string GetByRequestId(ConnectingList connectingList)
        {
            var temp1 = new ConnectingList {
                User1 = "1",
                User2 = "2"
            };
            var tmp1 = new ConnectingList
            {
                User1 = "1",
                User2 = "2"
            };
            var temp = GetAllRequest().Where(user1 => user1.User1 == connectingList.User1);
            temp1 = temp.FirstOrDefault(user2 => user2.User2 == connectingList.User2);
            var tmp = GetAllRequest().Where(user1 => user1.User1 == connectingList.User2);
            tmp1 = tmp.FirstOrDefault(user2 => user2.User2 == connectingList.User1);
            if (temp1 == null && tmp1 == null)
            {
                return "connect";
            }
            if (temp1 != null && tmp1 == null)
            {
                return "requestsent";
            }
            if (temp1 == null && tmp1 != null)
            {
                return "accept";
            }
            return ".";
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
            _context.ConnectingList.Add(connectModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequest(ConnectingList connectModel)
        {
            _context.ConnectingList.RemoveRange(connectModel);
            _context.ConnectingList.Remove(connectModel);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptRequest(ConnectedList connectModel)
        {
            _context.ConnectedList.Add(connectModel);
            await _context.SaveChangesAsync();
        }
    }
}

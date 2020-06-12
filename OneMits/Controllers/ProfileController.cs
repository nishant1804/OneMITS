
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.ApplicationUser;
using OneMits.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneMits.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _profileManager;
        private readonly IApplicationUser _profileImplementation;
        private readonly IApplicationUser _userImplementation;
        
        
        private ApplicationDbContext _context;
        public ProfileController(IApplicationUser profileImplementation, IApplicationUser userImplementation, UserManager<ApplicationUser> profileManager,ApplicationDbContext context)
        {
            _profileImplementation = profileImplementation;
            _profileManager = profileManager;
            _userImplementation = userImplementation;
            _context = context;
           
        }

        public IActionResult Details(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userRoles = _profileManager.GetRolesAsync(user).Result;
            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = usertmp,
                Receiver = user
            };
            var hasSendRequest = _profileImplementation.GetByRequestId(connectModel);
            var Notifications = new List<Notification>();
            var rNotifications = new List<Notification>();
            var uNotifications = new List<Notification>();
            Notifications = _profileImplementation.GetNotifications(usertmp).ToList();
            uNotifications = Notifications.Where(tmp11 => tmp11.Status == false).ToList();
            rNotifications = Notifications.Where(tmp11 => tmp11.Status == true).ToList();
            var unreadnotificationListing = uNotifications.Select(notification => new NotificationModel
            {
                notification = notification.notification,
                DateTime = notification.DateTime,
                UserFrom = notification.UserFrom.UserName,
                Controller = notification.Controller,
                Action = notification.Action,
                ActionId = notification.ActionId
            });
            var readnotificationListing = rNotifications.Where(tmp11 => tmp11.Status == true).Select(notification => new NotificationModel
            {
                notification = notification.notification,
                DateTime = notification.DateTime,
                UserFrom = notification.UserFrom.UserName,
                Controller = notification.Controller,
                Action = notification.Action,
                ActionId = notification.ActionId
            });
            _profileImplementation.MarkRead(usertmp).Wait();
            var model = new ProfileModel()
            {
                RequestOption = hasSendRequest,
                OpenUserId = userId,
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating,
                MemberSince = user.MemberSince,
                Email = user.Email,
                IsAdmin = userRoles.Contains("Admin"),
                notificationsunread = unreadnotificationListing,
                notificationsread = readnotificationListing
            };
           // _profileImplementation.AddNotificationCount(usertmp).Wait();
            return View(model);
        }
        public async Task<IActionResult> UnFriend(string id)
        {
            var user = _profileImplementation.GetById(id);

            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = usertmp,
                Receiver = user
            };

            
            await _userImplementation.UnFriend(connectModel);
            var notificationModel = new Notification {
                notification = " removed you from connection list",
                DateTime = DateTime.Now,
                UserFrom = usertmp,
                UserTo = user,
                Controller = "Profile",
                Action = "Details",
                ActionId = userId 
            };
            await _profileImplementation.AddNotification(notificationModel);
            return RedirectToAction("Details", new { id });
        }
        public async Task<IActionResult> CancelRequest(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = usertmp,
                Receiver = user
            };
            await _userImplementation.DeleteRequest(connectModel);
            var notificationModel = new Notification
            {
                notification = " canceled the connection request",
                DateTime = DateTime.Now,
                UserFrom = usertmp,
                UserTo = user,
                Controller = "Profile",
                Action = "Details",
                ActionId = userId
            };
            await _profileImplementation.AddNotification(notificationModel);
            return RedirectToAction("Details", new { id });
        }
        public async Task<IActionResult> DenyRequest(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = user,
                Receiver = usertmp
            };
            await _userImplementation.DenyRequest(connectModel);
            var notificationModel = new Notification
            {
                notification = "denied your connection request",
                DateTime = DateTime.Now,
                UserFrom = usertmp,
                UserTo = user,
                Controller = "Profile",
                Action = "Details",
                ActionId = userId
            };
            await _profileImplementation.AddNotification(notificationModel);
            return RedirectToAction("Details", new { id });
        }
        public async Task<IActionResult> AcceptRequest(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = user,
                Receiver = usertmp
            };
            await _userImplementation.AcceptRequest(connectModel);
            var notificationModel = new Notification
            {
                notification = "accepted your connection request",
                DateTime = DateTime.Now,
                UserFrom = usertmp,
                UserTo = user,
                Controller = "Profile",
                Action = "Details",
                ActionId = userId
            };
            await _profileImplementation.AddNotification(notificationModel);
            return RedirectToAction("Details", new { id });
        }
        public async Task<IActionResult> SendRequest(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userId = _profileManager.GetUserId(User);
            var usertmp = _profileManager.FindByIdAsync(userId).Result;
            var connectModel = new ConnectingList
            {
                Sender = usertmp,
                Receiver = user
            };
            await _userImplementation.SendRequest(connectModel);
            var notificationModel = new Notification
            {
                notification = "sent you connection request",
                DateTime = DateTime.Now,
                UserFrom = usertmp,
                UserTo = user,
                Controller = "Profile",
                Action = "Details",
                ActionId = userId
            };
            await _profileImplementation.AddNotification(notificationModel);
            return RedirectToAction("Details", id);
        }
        
        
        private ConnectingList BuildRequest(ConnectingList connectModel)
        {
            return new ConnectingList
            {
                Sender = connectModel.Sender,
                Receiver = connectModel.Receiver
            };
        }
        private ConnectedList BuildConnectedRequest(ConnectModel connectModel)
        {
            return new ConnectedList
            {
                User1 = connectModel.UserId1,
                User2 = connectModel.UserId2
            };
        }
        private ConnectedList BuildAcceptRequest(ConnectModel connectModel)
        {
            return new ConnectedList
            {
                User1 = connectModel.UserId1,
                User2 = connectModel.UserId2
            };
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
           
            await _userImplementation.Delete(id);
            
            return RedirectToAction("Index", "AdminPanel");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnDelete(string id)
        {

            await _userImplementation.UnDelete(id);

            return RedirectToAction("Index", "AdminPanel");
        }

    }
}
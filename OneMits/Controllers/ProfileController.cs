
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.ApplicationUser;
using OneMits.Models.Search;
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
        private static UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public ProfileController(IApplicationUser profileImplementation, IApplicationUser userImplementation,UserManager<ApplicationUser> profileManager,ApplicationDbContext context)
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
            var connectModel = new ConnectModel
            {
                UserId1 = _profileManager.GetUserId(User),
                UserId2 = id
            };
            var connectingModel = BuildRequest(connectModel);
            var hasSendRequest = _profileImplementation.GetByRequestId(connectingModel);
            var model = new ProfileModel()
            {
                RequestOption = hasSendRequest,
                OpenUserId = connectModel.UserId1,
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating,
                MemberSince = user.MemberSince,
                Email = user.Email,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }

        public async Task<IActionResult> SendRequest(string id)
        {
            var connectModel = new ConnectModel
            {
                UserId1 = _profileManager.GetUserId(User),
                UserId2 = id
            };
            
            var connectingModel = BuildRequest(connectModel);
            await _userImplementation.SendRequest(connectingModel);

            return RedirectToAction("Profile", "Details", id);
        }
        public async Task<IActionResult> AcceptRequest(string id)
        {
            var connectModel = new ConnectModel
            {
                UserId1 = _profileManager.GetUserId(User),
                UserId2 = id
            };

            var connectingModel = BuildAcceptRequest(connectModel);
            await _userImplementation.AcceptRequest(connectingModel);

            connectModel.UserId1 = id;
            connectModel.UserId2 = _profileManager.GetUserId(User);
            var DeleteModel = BuildRequest(connectModel);
            await _userImplementation.DeleteRequest(DeleteModel);
            return RedirectToAction("Profile", "Details", new { id = connectModel.UserId1 });
        }
        private ConnectedList BuildAcceptRequest(ConnectModel connectModel)
        {
            return new ConnectedList
            {
                User1 = connectModel.UserId1,
                User2 = connectModel.UserId2
            };
        }
        public async Task<IActionResult> CancelRequest(string id)
        {
            var connectModel = new ConnectModel
            {
                UserId1 = _profileManager.GetUserId(User),
                UserId2 = id
            };

            var connectingModel = BuildRequest(connectModel);
            await _userImplementation.DeleteRequest(connectingModel);

            return RedirectToAction("Profile", "Details", new { id = connectModel.UserId2 });
        }
        public async Task<IActionResult> DenyRequest(string id)
        {
            var connectModel = new ConnectModel
            {
                UserId1 = id,
                UserId2 = _profileManager.GetUserId(User)
            };

            var connectingModel = BuildRequest(connectModel);
            await _userImplementation.DeleteRequest(connectingModel);

            return RedirectToAction("Profile", "Details", new { id = connectModel.UserId1 });
        }
        private ConnectingList BuildRequest(ConnectModel connectModel)
        {
            return new ConnectingList
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
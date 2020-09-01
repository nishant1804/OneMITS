using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EtherealMade.Data;
using EtherealMade.Data.Models;
using EtherealMade.Models.Status;

namespace EtherealMade.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly IStatus _statusImplementation;
        private static UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _applicationUserImplementation;
        public StatusController(IStatus statusImplementation, IApplicationUser applicationUserImplementation, UserManager<ApplicationUser> userManager)
        {
            _statusImplementation = statusImplementation;
            _userManager = userManager;
            _applicationUserImplementation = applicationUserImplementation;
        }


        public IActionResult Index()
        {
            
            var status = _statusImplementation.GetAll().Select(tag => new StatusListingModel
            {
                StatusCreated = tag.StatusCreated,
                NumberView = tag.NumberViews,
                StatusId = tag.StatusId,
                StatusTitle = tag.StatusTitle,
                AuthorId = tag.User.Id,
                AuthorName = tag.User.UserName,

            });
            var model = new StatusIndexModel
            {
                StatusList = status
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new AddStatusModel
            {
                AuthorName = User.Identity.Name
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddStatus(AddStatusModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var status = BuildPost(model, user);

            string[] censoredWords = System.IO.File.ReadAllLines(@"CensoredWords.txt");
            Censor censor = new Censor(censoredWords);
            status.StatusTitle = censor.CensorText(status.StatusTitle);

            await _statusImplementation.AddStatus(status);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Status));

            return RedirectToAction("Index", "Status", new { id = status.StatusId });
        }

        private Status BuildPost(AddStatusModel model, ApplicationUser user)
        {
            return new Status
            {
                StatusTitle = model.StatusTitle,
                StatusCreated = DateTime.Now,
                User = user,
            };
        }
    }
}


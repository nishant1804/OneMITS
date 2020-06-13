using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.Status;
using OneMits.Models.StatusCategory;

namespace OneMits.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly IStatus _statusImplementation;
        private static UserManager<ApplicationUser> _userManager;
        private readonly IStatusCategory _statuscategoryImplementation;
        private readonly IApplicationUser _applicationUserImplementation;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public StatusController(IStatus statusImplementation, IApplicationUser applicationUserImplementation, ILogger<HomeController> logger, IConfiguration config,  IStatusCategory statuscategoryImplementation, UserManager<ApplicationUser> userManager)
        {
            _statusImplementation = statusImplementation;
            _userManager = userManager;
            _applicationUserImplementation = applicationUserImplementation;
            _statuscategoryImplementation = statuscategoryImplementation;
            _logger = logger;
            _config = config;

        }
        
        public IActionResult Index(StatusCategoryListingModel dol)
        {
            var temp = _statuscategoryImplementation.GetById(dol.StatusCategoryId);
            
            var statusset = _statuscategoryImplementation.GetAll();
            var statuscategory = statusset.Select(category => new StatusCategory
            {
                StatusCategoryId = category.StatusCategoryId,
                StatusCategoryTitle = category.StatusCategoryTitle,
                Status = category.Status
            });
            var status = _statusImplementation.GetAll();
            var statusListings = status.Select(q => new StatusListingModel
            {

                StatusId = q.StatusId,
                AuthorName = q.User.UserName,
                StatusTitle = q.StatusTitle,
                StatusCreated = q.StatusCreated,
                NumberView = q.NumberViews,
                StatusCategoryId = q.StatusCategory.StatusCategoryId
            });

            var model = new StatusCatogeryTopicModel
            {
                Status = statusListings,
                StatusCategory = statuscategory,
                StatusCategoryDrop = temp
            };
            return View(model);
            
        }
        [HttpPost]
        public IActionResult Index(string StatusCategoryId, string StatusCategoryTitle, StatusCategoryListingModel dol)
        {
            var temp = _statuscategoryImplementation.GetById(dol.StatusCategoryId);

            ViewBag.Message = "Department Id: " + temp.StatusCategoryId;
            ViewBag.Message += "\\ | Department Name: " + temp.StatusCategoryTitle;
            var statusset = _statuscategoryImplementation.GetAll();
            var statuscategory = statusset.Select(category => new StatusCategory
            {
                StatusCategoryId = category.StatusCategoryId,
                StatusCategoryTitle = category.StatusCategoryTitle,
                Status = category.Status
            });
            var status = _statusImplementation.GetAll();

            var statusListings = status.Select(q => new StatusListingModel
            {

                StatusId = q.StatusId,
                AuthorName = q.User.UserName,
                StatusTitle = q.StatusTitle,
                StatusCreated = q.StatusCreated,
                NumberView = q.NumberViews,
                StatusCategoryId = q.StatusCategory.StatusCategoryId
            });

            var model = new StatusCatogeryTopicModel
            {
                Status = statusListings,
                StatusCategory = statuscategory,
                StatusCategoryDrop = temp
            };
            return View(model);
        }

        
        public IActionResult Create()
        {
            var StatusCategoryListingModel = _statuscategoryImplementation.GetAll().Select(q => new StatusCategoryListingModel
            {
                StatusCategoryId = q.StatusCategoryId,
                StatusCategoryTitle = q.StatusCategoryTitle,
                
            });
 
            var model = new AddStatusModel
            {
                StatusCategory = StatusCategoryListingModel,
                AuthorName = User.Identity.Name,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddStatus(AddStatusModel model , StatusCategoryListingModel dol)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var status = BuildPost(model, user, dol);

            string[] censoredWords = System.IO.File.ReadAllLines(@"CensoredWords.txt");
            Censor censor = new Censor(censoredWords);
            status.StatusTitle = censor.CensorText(status.StatusTitle);
            


            await _statusImplementation.AddStatus(status);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Status));

            return RedirectToAction("Index", "Status", new { id = status.StatusId });
        }

        private Status BuildPost(AddStatusModel model, ApplicationUser user, StatusCategoryListingModel dol)
        {
            var category = _statuscategoryImplementation.GetById(dol.StatusCategoryId);
            return new Status
            {
                StatusTitle = model.StatusTitle,
                StatusCreated = DateTime.Now,
                StatusCategory = category,
                User = user,
            };
        }


    }
}


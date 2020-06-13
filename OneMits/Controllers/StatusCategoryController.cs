using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMits.Models.Status;
using OneMits.Data.Models;
using OneMits.Data;
using OneMits.Models.StatusCategory;



namespace OneMits.Controllers
{
    public class StatusCategoryController : Controller
    {
        private readonly IStatusCategory _statuscategoryImplementation;
        private readonly IStatus _statusImplementation;
        public StatusCategoryController(IStatusCategory statuscategoryImplementation, IStatus statusImplementation)
        {
            _statuscategoryImplementation = statuscategoryImplementation;
            _statusImplementation = statusImplementation;
        }

        public IActionResult Index()
        {
            var categories = _statuscategoryImplementation.GetAll().Select(category => new StatusCategoryListingModel
            {
                StatusCategoryId = category.StatusCategoryId,
                StatusCategoryTitle = category.StatusCategoryTitle,
                
            });
            var model = new StatusCategoryIndexModel
            {
                StatusCategoryList = categories
            };
            return View(model);
        }

        //private StatusCategoryListingModel BuildStatusListing(Status status)
        //{
        //    var statuscategory = status.StatusCategory;
        //    return BuildForumListing(statuscategory);
        //}

        //private StatusCategoryListingModel BuildForumListing(Data.Models.StatusCategory statuscategory)
        //{
        //    return new StatusCategoryListingModel
        //    {
        //        StatusCategoryId = statuscategory.StatusCategoryId,
        //        StatusCategoryTitle = statuscategory.StatusCategoryTitle,
        //    };
        //}

        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory()
        {
            var model = new AddStatusCategoryModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(AddStatusCategoryModel model)
        {
            var statuscategory = new Data.Models.StatusCategory
            {
                StatusCategoryTitle = model.StatusCategoryTitle,
            };
            await _statuscategoryImplementation.CreateModel(statuscategory);
            return RedirectToAction("Index", "Status");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statuscategoryImplementation.Delete(id);
            return RedirectToAction("Index", "Status");
        }
    }
}
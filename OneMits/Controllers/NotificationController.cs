using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EtherealMade.Data;
using EtherealMade.Data.Models;
using EtherealMade.InterfaceImplementation;
using EtherealMade.Models.ApplicationUser;

namespace EtherealMade.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
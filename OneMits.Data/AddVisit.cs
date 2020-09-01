using Microsoft.AspNetCore.Http;
using EtherealMade.Data.Models;
using System;
using System.Threading.Tasks;

namespace EtherealMade.Data
{
    public class AddVisit
    {
       // private readonly 
        private readonly IApplicationUser _applicationUserImplementation;
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;

        public AddVisit(IApplicationUser applicationUserImplementation, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _applicationUserImplementation = applicationUserImplementation;
            _accessor = httpContextAccessor;
            _context = context;
        }
        public async Task WebVisit()
        {
            //var ipAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var Visit = new Visits
            {
                Time = DateTime.Now,
                IpAddress = "Http",
            };
            await _applicationUserImplementation.AddVisit(Visit);
            await _context.SaveChangesAsync();
        }
    }
}

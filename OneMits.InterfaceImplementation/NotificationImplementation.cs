using Microsoft.EntityFrameworkCore;
using EtherealMade.Data;
using EtherealMade.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherealMade.InterfaceImplementation
{
    public class NotificationImplementation : INotification
    {
        private readonly ApplicationDbContext _context;

        public NotificationImplementation(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Notification notification)
        {
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();
        }
    }
}

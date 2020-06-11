using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
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

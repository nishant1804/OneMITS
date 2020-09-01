using EtherealMade.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EtherealMade.Data
{
    public interface INotification
    {
        Task Add(Notification notification);
    }
}

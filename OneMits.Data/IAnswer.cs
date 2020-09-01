using EtherealMade.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EtherealMade.Data
{
    public interface IAnswer
    {
        
        Answer GetById(string id);
        IEnumerable<Answer> GetAll();
        Task Delete(int id);

    }
}

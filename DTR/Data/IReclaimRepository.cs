using DTR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTR.Data
{

    public interface IReclaimRepository
    {

        IEnumerable<Reclaim> GetAllReclaims();

        IEnumerable<Reclaim> GetReadyToAttachTrade();

        bool SaveChanges();
    }
}

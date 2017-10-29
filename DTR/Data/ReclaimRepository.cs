using DTR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTR.Data
{

    //todo: async
    public class ReclaimRepository : IReclaimRepository
    {
        private readonly ReclaimContext _context;
        private readonly ILogger<ReclaimRepository> _logger;


        public ReclaimRepository(ReclaimContext context, ILogger<ReclaimRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<Reclaim> GetAllReclaims()
        {
            return _context.Reclaims.OrderBy(d => d.Created).ToList();
        }


        //https://ef.readthedocs.io/en/staging/querying/related-data.html
        public IEnumerable<Reclaim> GetReadyToAttachTrade()
        {
            try
            {
                return _context.Reclaims                   
                    .Include(reclaim => reclaim.CreatedBy)
                    .Include(reclaim => reclaim.ReclaimState)
                      .Where(d => d.ReclaimState.ID == (int)InstanceState.New)
                    .ToList();
                   
            }catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw;
            }
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

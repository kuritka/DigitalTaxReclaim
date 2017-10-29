using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTR.Data.Entities
{
    public class Reclaim
    {
        public int ID { get; set; }

        public string Product { get; set; }

        public string Message { get; set; }

        public decimal TradeInformation { get; set; }

        public ReclaimState ReclaimState { get; set; }

        public DateTime Created { get; set; }

       // public int? OpenedById { get; set; }
       // public Account OpenedBy { get; set; }

        //public int? CreatedById { get; set; }
        public Account CreatedBy { get; set; }
    }


    public class Account : IdentityUser
    {

        public string Name { get; set; }

        ICollection<Reclaim> Reclaims { get; set; }
    }

    public class ReclaimState
    {
        public int ID { get; set; }

        public string Name { get; set; }

        ICollection<Reclaim> Reclaims { get; set; }
    }


    public enum InstanceState
    {
        New = 1,
        AttachedTradeInformation,
        ReviewedByTeam,
        ApprovedByAccountManager,
        Refused
    }
}

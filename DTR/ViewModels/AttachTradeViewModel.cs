using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTR.ViewModels
{
    public class AttachTradeViewModel
    {
        public IEnumerable<decimal> TradeInformations { get; set; }
    }


    public class AttachTradeDetailViewModel : ReclaimViewModel
    {

        [Required]
        [Range(0,Int32.MaxValue)]
        public int ID { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal TradeInformation { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }
    }


}

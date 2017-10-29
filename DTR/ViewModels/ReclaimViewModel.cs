using DTR.Common;
using System.ComponentModel.DataAnnotations;

namespace DTR.ViewModels
{
    public class ReclaimViewModel
    {

        [Required]
        public string Product { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}

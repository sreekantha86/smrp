using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pms.domain
{
    public class TenantType
    {
        public int tentTypeId { get; set; }
        [Required]
        [Display(Name = "Tenant Type")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string tentTypeName { get; set; }
        [Required]
        [Display(Name = "Remarks")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string tentTypeRemarks { get; set; }
    }
}

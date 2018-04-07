using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pms.domain
{
    public class Tenant
    {
        public int tentId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string tentName { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int tentTypeId { get; set; }
        [Required]
        [Display(Name = "Mobile number")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string tentMobNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-Mail")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string tentEmail { get; set; }
        [Display(Name = "Permanat Address")]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string tentPermanantAddress { get; set; }
        [Display(Name = "Communication Address")]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string tentCommAddress { get; set; }

    }
}

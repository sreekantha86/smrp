using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pms.domain
{
    public class User
    {
        public int usrId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string usrUserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string usrPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("usrPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string usrEmployeeName { get; set; }
        [Display(Name = "e-Mail")]
        [DataType(DataType.EmailAddress)]
        public string usrEmail { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime usrExpiry { get; set; }
        public Guid usrGUID { get; set; }
        public DateTime usrLastUpdate { get; set; }
    }
}

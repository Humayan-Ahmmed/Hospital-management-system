using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doctors247.Models
{
    public class d_registration
    {
        [Required(ErrorMessage = "Please ennter your Username", AllowEmptyStrings = false)]
        public string username { get; set; }

        public int doctor_id { get; set; }

        [Required(ErrorMessage = "Please enter your firstname", AllowEmptyStrings = false)]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Please ennter your lastname", AllowEmptyStrings = false)]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Please ennter your email", AllowEmptyStrings = false)]
        public string email { get; set; }

        [Required(ErrorMessage = "Please ennter your password", AllowEmptyStrings = false)]
        public string pass { get; set; }


        [Required(ErrorMessage = "Please ennter your contact", AllowEmptyStrings = false)]
        public int contactNO { get; set; }


        [Required(ErrorMessage = "Please ennter your speciality", AllowEmptyStrings = false)]
        public string speciality { get; set; }


        [Required(ErrorMessage = "Please ennter your address", AllowEmptyStrings = false)]
        public string Addresss { get; set; }


        [Required(ErrorMessage = "Please ennter your designation")]
        public string designation { get; set; }

        [Required(ErrorMessage = "Please ennter your fees", AllowEmptyStrings = false)]
        public int Fees { get; set; }
    }
}
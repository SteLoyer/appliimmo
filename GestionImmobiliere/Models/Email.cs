using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionImmobiliere.Models
{
    public class Email
    {
        [Required, Display(Name = "Your name")]
        public string Name_Tenant { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string Email_tenant { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
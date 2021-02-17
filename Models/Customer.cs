using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videly.Models
{
    public class Customer
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Please enter a valid name")]
        [StringLength(255)]
        public string  Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
       
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name ="Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGO = 0;

    }
}
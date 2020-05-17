using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name."), StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public bool Delinquent { get; set; }
        public MembershipType MembershipType { get; set; }
        //a foreign  key so we don't have to use the navigation property always

        [Display(Name = "Memebership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]//optional field unless user selects pay as you go
        public DateTime? BirthDate { get; set; } //make it nullable prevents  1 jan 0001

        [Display(Name = "Discount rate")]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Discount rate must be a percent of 100.")]
        public int DiscountRate { get; set; }
    }
}
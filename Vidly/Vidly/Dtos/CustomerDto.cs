using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public bool Delinquent { get; set; }

        //a foreign  key so we don't have to use the navigation property always

        //we created a Dto so we don't couple our model(Membership model) to our Dto
        //WE only use it to present membership types to the user in GET method
        //WE DON'T CHANGE MEMBERSHIP TYPES
        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        // [Min18YearsIfAMember]//optional field unless user selects pay as you go
        public DateTime? BirthDate { get; set; } //make it nullable prevents  1 jan 0001

        [Display(Name = "Discount rate")]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Discount rate must be between 0 and 100.")]
        public int DiscountRate { get; set; }
    }
}
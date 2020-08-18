/// <summary>
/// Customer Data Class
/// Author: Martina Rizk
/// Date: August 5, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableReady.Group5.Domain
{
    
    [Table("Customer")]
    public class Customer
    {
        public int ID { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public ICollection<WaitList> WaitLists { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Reward> Rewards { get; set; }
    }
}

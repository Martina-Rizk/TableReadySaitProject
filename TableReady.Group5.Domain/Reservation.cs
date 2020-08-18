/// <summary>
/// Reservation Data Class
/// Author: Martina Rizk
/// Date: August 5, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TableReady.Group5.Domain
{
    [Table("Reservation")]
    public class Reservation
    {
        public int ID { get; set; }
        public string ReservationStatus { get; set; }
        public DateTime ReservationDate { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

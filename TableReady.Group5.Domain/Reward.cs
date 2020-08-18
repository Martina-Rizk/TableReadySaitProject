/// <summary>
/// Rewards Data Class
/// Author: Martina Rizk & Sohail Umer
/// Date: August 5, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TableReady.Group5.Domain
{
    [Table("Reward")]
    public class Reward
    {
        public int ID { get; set; }
        public int Points { get; set; }
        public decimal Discount { get; set; }
        public string FreeProduct { get; set; }
        public int CustomerID { get; set; }
        public int? RestaurantID { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool? IsChecked { get; set; }  // Author: Sohail Umer
        public string CheckedValue { get; set; } // Author: Sohail Umer
    }
}

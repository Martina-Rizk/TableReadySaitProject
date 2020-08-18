/// <summary>
/// WaitList Data Class
/// Author: Martina Rizk
/// Date: August 5, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace TableReady.Group5.Domain
{
    [Table("WaitList")]
    public class WaitList
    {
        public int ID { get; set; }
        public int Position { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

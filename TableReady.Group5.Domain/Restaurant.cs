/// <summary>
/// Simple Restaurants Data Class
/// Author: Martina Rizk
/// Date: August 5, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TableReady.Group5.Domain
{
    
    [Table("Restaurant")]
    public class Restaurant
    {
        public int ID { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        public string RestaurantDescription { get; set; }

        [Column(TypeName = "Image")]
        public byte[] RestaurantImage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TableReady.Group5.Domain
{
    public class Review
    {
        [Display(Name = "Review From Facebook")]
        public string FromFacebook { get; set; }

        [Display(Name = "Review From Google")]
        public string FromGoogle { get; set; }

        [Display(Name = "Review From Table Ready")]
        public string FromTableReady { get; set; }

        [Display(Name = "CheckedIn Status")]
        public string reviewValue { get; set; }
    }
}

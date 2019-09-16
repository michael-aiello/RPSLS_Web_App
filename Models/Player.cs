using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPSLS_Web_App.Models
{
    public class Player
    {
        public int ID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public string Name { get; set; }

        // using System.ComponentModel.DataAnnotations;
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; } // date record is created

        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; } // date record is modified
    }
}

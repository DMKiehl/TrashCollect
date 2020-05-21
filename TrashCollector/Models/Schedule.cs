using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="date")]
        public DateTime date { get; set; }

        public bool PickedUp { get; set; }
        [Column(TypeName = "date")]
        public DateTime holdStart { get; set; }
        [Column(TypeName = "date")]
        public DateTime holdEnd { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerZipCode { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("Day")]
        public int DayId { get; set; }
        public string DayName { get; set; }
        public Day day { get; set; }
    }
}

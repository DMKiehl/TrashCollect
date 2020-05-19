using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }
        public double Charge { get; set; }
        public bool Paid { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Schedule schedule { get; set; }
    }
}

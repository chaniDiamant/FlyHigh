using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlyHigh.Models
{
    public class Order
    {
        [DisplayName("מספר הזמנה")]
        public int OrderId { get; set; }

        [DisplayName("תאריך הזמנה")]
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class DienosAutomobilis
    {
        [Required]
        public int Id { get; set; }
        public DateTime day { get; set; }
        public Pareigunas pareigunas { get; set; }
        public Automobilis automobilis { get; set; }
    }
}

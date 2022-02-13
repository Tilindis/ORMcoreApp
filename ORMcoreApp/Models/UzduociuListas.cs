using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class UzduociuListas
    {
        [Required]
        public int Id { get; set; }
        public DateTime day { get; set; }
        public int Frequency { get; set; }
        public Uzduotis uzduotis { get; set; }
        public int pareigunasId { get; set; }
        public Pareigunas pareigunas { get; set; }
    }
}

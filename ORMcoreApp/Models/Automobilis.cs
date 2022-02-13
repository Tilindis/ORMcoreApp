using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class Automobilis
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string VinId { get; set; }
        [StringLength(20)]
        public string CarMake { get; set; }
        [StringLength(20)]
        public string CarModel { get; set; }
        public int Passengers { get; set; }
        public ICollection<DienosAutomobilis> SkirtinguDienuAutomobilis { get; set; }
    }
}

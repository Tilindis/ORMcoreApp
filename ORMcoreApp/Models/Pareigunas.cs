using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class Pareigunas
    {
        [Required]
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        public int Unit { get; set; }
        [StringLength(15)]
        public string Role { get; set; }
        public ICollection<DienosAutomobilis> SkirtinguDienuAutomobilis { get; set; }
        public UzduociuListas uzduociuListas { get; set; }
        public int ginklasId { get; set; }
        public Ginklas ginklas { get; set; }
    }
}

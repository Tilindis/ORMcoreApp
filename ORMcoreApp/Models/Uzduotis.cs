using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class Uzduotis
    {
        [Required]
        public int Id { get; set; }
        [StringLength(25)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public ICollection<UzduociuListas> Uzduotys { get; set; }
    }
}

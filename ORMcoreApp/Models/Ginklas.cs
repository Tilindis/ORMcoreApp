using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMcoreApp.Models
{
    public class Ginklas
    {
        [Required]
        public int Id { get; set; }
        [StringLength(20)]
        public string GunName { get; set; }
        [StringLength(20)]
        public string GunModel { get; set; }
        public int GunID { get; set; }
        //public int pareigunasId { get; set; }
        public Pareigunas pareigunas { get; set; }
    }
}

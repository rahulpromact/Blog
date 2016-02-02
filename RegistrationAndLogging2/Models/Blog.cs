using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegistrationAndLogging2.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Blogtitle { get; set; }
        public string BlogDescription { get; set; }
        public DateTime BlogDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}
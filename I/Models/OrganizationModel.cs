using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace I.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string OrganizationCode { get; set; }
        public int OrganizationStatusID { get; set; }
        [ForeignKey("OrganizationStatusID")]
        public virtual Organization_Status Organization_Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }
}
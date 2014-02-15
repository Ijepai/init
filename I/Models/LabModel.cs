using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I.Models
{
    public class Lab
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile Instructor { get; set; }
        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public virtual Lab_Status Lab_Status { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I.Models
{
    public class Participant
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
        public int LabID { get; set; }
        [ForeignKey("LabID")]
        public virtual Lab Lab { get; set; }
        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public Participant_Status Participant_Status { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }
}
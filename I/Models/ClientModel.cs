using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I.Models
{
    public class Client
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ClientStatusID { get; set; }
        [ForeignKey("ClientStatusID")]
        public virtual Client_Status Client_Status { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public virtual ICollection<Client_Email> Emails { get; set; }
        public virtual ICollection<Client_Phone> Phone_Numbers { get; set; }
        public virtual ICollection<Client_Address> Addresses { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }
}
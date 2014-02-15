using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I.Models
{
    public class Client_Email
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        public string Email { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Client_Phone
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        public string Phone_Number { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Client_Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        public string Address;
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class User_Email
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile User { get; set; }
        public string Email { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class User_Phone
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile User { get; set; }
        public string Phone { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class User_Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public byte If_Primary { get; set; }
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organization { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile User { get; set; }
        public string Address { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }
}
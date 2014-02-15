using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I.Models
{
    public class Organization_Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class User_Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Participant_Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Client_Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Lab_Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Status { get; set; }
        [StringLength(32)]
        public string Hkey { get; set; }
    }

    public class Response
    {
        public int Status;
        public string Message;
        public dynamic Data;
    }
}
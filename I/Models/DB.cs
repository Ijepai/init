using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace I.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<Organization> Organizations { get; set; }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Client_Email> Client_Emails { get; set; }
        public DbSet<Client_Phone> Client_Phone_Numbers { get; set; }
        public DbSet<Client_Address> Client_Addresses { get; set; }

        public DbSet<User_Email> User_Emails { get; set; }
        public DbSet<User_Phone> User_Phone_Numbers { get; set; }
        public DbSet<User_Address> User_Addresses { get; set; }

        public DbSet<Organization_Status> Organization_Status { get; set; }
        public DbSet<Lab_Status> Lab_Status { get; set; }
        public DbSet<Participant_Status> Participant_Status { get; set; }
        public DbSet<Client_Status> Client_Status { get; set; }
        public DbSet<User_Status> User_Status { get; set; }
    }
}
namespace I.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrganizationCode = c.String(),
                        OrganizationStatusID = c.Int(nullable: false),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organization_Status", t => t.OrganizationStatusID)
                .Index(t => t.OrganizationStatusID);
            
            CreateTable(
                "dbo.Organization_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        OrganizationID = c.Int(nullable: false),
                        UserStatusID = c.Int(nullable: false),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.userID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.User_Status", t => t.UserStatusID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserStatusID);
            
            CreateTable(
                "dbo.User_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User_Email",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Email = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.UserProfile", t => t.UserID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User_Phone",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Phone = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.UserProfile", t => t.UserID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User_Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Address = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.UserProfile", t => t.UserID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Name = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.UserProfile", t => t.UserID)
                .ForeignKey("dbo.Lab_Status", t => t.StatusID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Lab_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LabID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.UserProfile", t => t.UserID)
                .ForeignKey("dbo.Labs", t => t.LabID)
                .ForeignKey("dbo.Participant_Status", t => t.StatusID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.OrganizationID)
                .Index(t => t.UserID)
                .Index(t => t.LabID)
                .Index(t => t.StatusID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Participant_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientStatusID = c.Int(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client_Status", t => t.ClientStatusID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .Index(t => t.ClientStatusID)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Client_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Client_Email",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Email = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.OrganizationID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Client_Phone",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Phone_Number = c.String(),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.OrganizationID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Client_Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        If_Primary = c.Byte(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Hkey = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.OrganizationID)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Client_Address", new[] { "ClientID" });
            DropIndex("dbo.Client_Address", new[] { "OrganizationID" });
            DropIndex("dbo.Client_Phone", new[] { "ClientID" });
            DropIndex("dbo.Client_Phone", new[] { "OrganizationID" });
            DropIndex("dbo.Client_Email", new[] { "ClientID" });
            DropIndex("dbo.Client_Email", new[] { "OrganizationID" });
            DropIndex("dbo.Clients", new[] { "OrganizationID" });
            DropIndex("dbo.Clients", new[] { "ClientStatusID" });
            DropIndex("dbo.Participants", new[] { "ClientID" });
            DropIndex("dbo.Participants", new[] { "StatusID" });
            DropIndex("dbo.Participants", new[] { "LabID" });
            DropIndex("dbo.Participants", new[] { "UserID" });
            DropIndex("dbo.Participants", new[] { "OrganizationID" });
            DropIndex("dbo.Labs", new[] { "StatusID" });
            DropIndex("dbo.Labs", new[] { "UserID" });
            DropIndex("dbo.Labs", new[] { "OrganizationID" });
            DropIndex("dbo.User_Address", new[] { "UserID" });
            DropIndex("dbo.User_Address", new[] { "OrganizationID" });
            DropIndex("dbo.User_Phone", new[] { "UserID" });
            DropIndex("dbo.User_Phone", new[] { "OrganizationID" });
            DropIndex("dbo.User_Email", new[] { "UserID" });
            DropIndex("dbo.User_Email", new[] { "OrganizationID" });
            DropIndex("dbo.UserProfile", new[] { "UserStatusID" });
            DropIndex("dbo.UserProfile", new[] { "OrganizationID" });
            DropIndex("dbo.Organizations", new[] { "OrganizationStatusID" });
            DropForeignKey("dbo.Client_Address", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Client_Address", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Client_Phone", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Client_Phone", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Client_Email", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Client_Email", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Clients", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Clients", "ClientStatusID", "dbo.Client_Status");
            DropForeignKey("dbo.Participants", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Participants", "StatusID", "dbo.Participant_Status");
            DropForeignKey("dbo.Participants", "LabID", "dbo.Labs");
            DropForeignKey("dbo.Participants", "UserID", "dbo.UserProfile");
            DropForeignKey("dbo.Participants", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Labs", "StatusID", "dbo.Lab_Status");
            DropForeignKey("dbo.Labs", "UserID", "dbo.UserProfile");
            DropForeignKey("dbo.Labs", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.User_Address", "UserID", "dbo.UserProfile");
            DropForeignKey("dbo.User_Address", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.User_Phone", "UserID", "dbo.UserProfile");
            DropForeignKey("dbo.User_Phone", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.User_Email", "UserID", "dbo.UserProfile");
            DropForeignKey("dbo.User_Email", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.UserProfile", "UserStatusID", "dbo.User_Status");
            DropForeignKey("dbo.UserProfile", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "OrganizationStatusID", "dbo.Organization_Status");
            DropTable("dbo.Client_Address");
            DropTable("dbo.Client_Phone");
            DropTable("dbo.Client_Email");
            DropTable("dbo.Client_Status");
            DropTable("dbo.Clients");
            DropTable("dbo.Participant_Status");
            DropTable("dbo.Participants");
            DropTable("dbo.Lab_Status");
            DropTable("dbo.Labs");
            DropTable("dbo.User_Address");
            DropTable("dbo.User_Phone");
            DropTable("dbo.User_Email");
            DropTable("dbo.User_Status");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Organization_Status");
            DropTable("dbo.Organizations");
        }
    }
}

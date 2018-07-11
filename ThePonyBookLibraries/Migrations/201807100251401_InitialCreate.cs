namespace ThePonyBookLibraries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        FirstName = c.String(maxLength: 256),
                        LastName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContactAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Address1 = c.String(maxLength: 256),
                        Address2 = c.String(maxLength: 256),
                        City = c.String(maxLength: 256),
                        Region = c.String(maxLength: 256),
                        PostalCode = c.String(maxLength: 256),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(maxLength: 20),
                        CountryName = c.String(maxLength: 256),
                        PhoneCountryCode = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPhone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        AreaCode = c.Int(),
                        Phone = c.Int(),
                        PhoneType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneType", t => t.PhoneType_Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.PhoneType_Id);
            
            CreateTable(
                "dbo.PhoneType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneTypeName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.__MigrationHistory",
            //    c => new
            //        {
            //            MigrationId = c.String(nullable: false, maxLength: 150),
            //            ContextKey = c.String(nullable: false, maxLength: 300),
            //            Model = c.Binary(nullable: false),
            //            ProductVersion = c.String(nullable: false, maxLength: 32),
            //        })
            //    .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.RoleId)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactPhone", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactPhone", "PhoneType_Id", "dbo.PhoneType");
            DropForeignKey("dbo.ContactAddress", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactAddress", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.ContactPhone", new[] { "PhoneType_Id" });
            DropIndex("dbo.ContactPhone", new[] { "ContactId" });
            DropIndex("dbo.ContactAddress", new[] { "Country_Id" });
            DropIndex("dbo.ContactAddress", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.PhoneType");
            DropTable("dbo.ContactPhone");
            DropTable("dbo.Country");
            DropTable("dbo.ContactAddress");
            DropTable("dbo.Contacts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}

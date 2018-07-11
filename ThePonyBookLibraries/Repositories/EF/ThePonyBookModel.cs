using System;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace ThePonyBookLibraries.Repositories.EF
{
    using System.Data.Entity;

    public class ThePonyBookModel : DbContext, IDbContext
    {
        public ThePonyBookModel()
            : base("name=ThePonyBookConnection")
        {

        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactAddress> ContactAddresses { get; set; }
        public virtual DbSet<ContactPhone> ContactPhones { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Contact>();
            config.ToTable("Contacts");

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.ContactAddresses)
                .WithRequired(e => e.Contact)
                .HasForeignKey(e => e.ContactId);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.ContactAddresses)
                .WithRequired(e => e.Contact)
                .HasForeignKey(e => e.ContactId);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.ContactPhones)
                .WithRequired(e => e.Contact)
                .HasForeignKey(e => e.ContactId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);
        }
    }

    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactAddress> ContactAddresses { get; set; }
        DbSet<ContactPhone> ContactPhones { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<PhoneType> PhoneTypes { get; set; }

        Task<int> SaveChangesAsync();
    }
}

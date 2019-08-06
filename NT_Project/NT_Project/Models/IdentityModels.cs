using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NT_Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {


        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Gender { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Post> Posts { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Interaction> Interactions { get; set; }
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty("First")]

        public virtual ICollection<Relationship> FirstRelationships { get; set; }



        [InverseProperty("Second")]

        public virtual ICollection<Relationship> SecondRelationships { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("FB_DB")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
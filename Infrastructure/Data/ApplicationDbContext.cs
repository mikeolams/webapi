using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RegistrationForm> RegistrationForms { get; set; }

        public DbSet<ResumeForm> ResumeForms { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Price)
            //    .HasPrecision(18, 2); // Specify the precision and scale

            modelBuilder.Entity<RegistrationForm>()
                .HasKey(r => r.userId);

            modelBuilder.Entity<ResumeForm>()
                .HasKey(r => r.UserId);

            //modelBuilder.Entity<ResumeForm>()
            //    .HasOne(r => r.RegistrationForm)
            //    .WithOne(reg => reg.ResumeForm)
            //    .HasForeignKey<ResumeForm>(r => r.UserId);// Specify the relationship

            //modelBuilder.Entity<ResumeForm>()
            //    .HasKey(r => r.UserId);

            modelBuilder.Entity<ResumeForm>()
                .HasOne(r => r.RegistrationForm)
                .WithOne(reg => reg.ResumeForm)
                .HasForeignKey<ResumeForm>(r => r.UserId);

        }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.Price)
        //        .HasColumnType("decimal(18, 2)"); // Specify the column type with precision and scale
        //}

    }
}

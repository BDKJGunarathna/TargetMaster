using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TargetMaster.Models;

namespace TargetMaster.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //dbset props for each tables
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Targets> Targets { get; set; }
        public DbSet<TargetProgress> TargetProgresses { get; set; }
        public DbSet<PerformanceEvaluations> PerformanceEvaluations { get; set; }

        public DbSet<ChangeLog>ChangeLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TargetMasterDb;Integrated Security=True");
        }
        //fluent api configs
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            // Employees -> Targets
            modelbuilder.Entity<Targets>()
                 .HasOne(t => t.AssignedEmployee)
            .WithMany(e => e.TargetsAssignedTo)
            .HasForeignKey(t => t.AssignedTo)
            .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Targets>()
           .HasOne(t => t.AssignedByEmployee)
           .WithMany(e => e.TargetsAssignedBy)
           .HasForeignKey(t => t.AssignedBy)
           .OnDelete(DeleteBehavior.Restrict);

            // TargetProgress -> Target
            modelbuilder.Entity<TargetProgress>()
                .HasOne(tp => tp.Target)
                .WithMany(t => t.TargetProgresses)
                .HasForeignKey(tp => tp.TargetID)
                .OnDelete(DeleteBehavior.Cascade);

            // TargetProgress -> Employe
            modelbuilder.Entity<TargetProgress>()
                .HasOne(tp => tp.Employee)
                .WithMany(e => e.TargetProgresses)
                .HasForeignKey(tp => tp.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            //seed data


        }
    }
}
using System;
using TargetMaster.Models;

namespace TargetMaster.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            // Check if the database already has data
            if (!context.Employees.Any())
            {
                // Seed Employees
                var employees = EmployeeSeedData.GenerateEmployees(1000); // Generate 1,000 employees
                context.Employees.AddRange(employees);
                context.SaveChanges();

                // Seed Targets
                var targets = TargetSeedData.GenerateTargets(employees, 10000); // Generate 10,000 targets
                context.Targets.AddRange(targets);
                context.SaveChanges();

                // Seed Performance Evaluations
                var evaluations = PerformanceEvaluationSeedData.GenerateEvaluations(targets, 20000); // Generate 20,000 evaluations
                context.PerformanceEvaluations.AddRange(evaluations);
                context.SaveChanges();
            }
            }
    }
}

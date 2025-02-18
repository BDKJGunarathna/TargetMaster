using Bogus;

namespace TargetMaster.Models
{
    public static class EmployeeSeedData
    {
        public static List<Employees> GenerateEmployees(int count)
        {
            var faker = new Faker<Employees>()
                .RuleFor(e => e.EmployeeName, f => f.Name.FullName())
                .RuleFor(e => e.EmployeeRole, f => f.Name.JobTitle())
                .RuleFor(e => e.Department, f => f.Commerce.Department());

            return faker.Generate(count);
        }
    }
}

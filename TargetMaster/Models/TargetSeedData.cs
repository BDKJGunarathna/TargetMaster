using Bogus;

namespace TargetMaster.Models
{
    public static class TargetSeedData
    {
        public static List<Targets> GenerateTargets(List<Employees> employees, int count)
        {
            //var targetTypes = new[] { "Daily", "Weekly", "Monthly", "Quarterly", "Annual" };
            
            var faker = new Faker<Targets>()
                .RuleFor(t => t.Title, f => f.Lorem.Sentence())
                .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
                //.RuleFor(t => t.Type, f => f.PickRandom(targetTypes))
                .RuleFor(t => t.Weightage, f => f.Random.Int())
                .RuleFor(t => t.StartDate, f => f.Date.Past())
                .RuleFor(t => t.EndDate, f => f.Date.Future())
           
                .RuleFor(t => t.EmployeeId, f => f.PickRandom(employees).EmployeeId);

            return faker.Generate(count);
        }
    }
}

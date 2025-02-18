using Bogus;

namespace TargetMaster.Models
{
    public static class PerformanceEvaluationSeedData
    {
        public static List<PerformanceEvaluations> GenerateEvaluations(List<Targets> targets, int count)

        {
            var faker = new Faker<PerformanceEvaluations>()
                .RuleFor(e => e.EvaluationId, f => f.PickRandom(targets).TargetId)
                .RuleFor(e => e.EmployeeId, f => f.PickRandom(targets).EmployeeId)
                .RuleFor(e => e.Progress, f => f.Random.Decimal(0, 100))
                 .RuleFor(e => e.DateUpdated, f => f.Date.Past());
            
            

            return faker.Generate(count);
        }
    }
}

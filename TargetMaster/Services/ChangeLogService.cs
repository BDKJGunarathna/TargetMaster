using TargetMaster.Data;
using TargetMaster.Models;

namespace TargetMaster.Services
{
 

    public class ChangeLogService :IChangeLogService
    {
        private readonly ApplicationDbContext _context;

        public ChangeLogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void LogChange(string entityName, int entityId, string actionType, string oldValues, string newValues, string changedBy)
        {
            var log = new ChangeLog
            {
                EntityName = entityName,
                EntityId = entityId,
                ActionType = actionType,
                OldValues = oldValues,
                NewValues = newValues,
                ChangedBy = changedBy,
                ChangeTime = DateTime.UtcNow
            };

            _context.ChangeLogs.Add(log);
            _context.SaveChanges();
        }
    }
}

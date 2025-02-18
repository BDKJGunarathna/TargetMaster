namespace TargetMaster.Services
{
    public interface IChangeLogService
    {
        void LogChange(string entityName, int entityId, string actionType, string oldValues, string newValues, string changedBy);
    }
}

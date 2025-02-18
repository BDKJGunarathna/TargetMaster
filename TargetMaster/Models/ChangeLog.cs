namespace TargetMaster.Models
{
    public class ChangeLog
    {
        public int ChangeLogId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string ActionType { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}

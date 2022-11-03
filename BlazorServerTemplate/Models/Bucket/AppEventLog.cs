namespace BlazorServerTemplate.Models.Bucket
{
    public class AppEventLog
    {
        public int? StartLogID { get; set; }
        public string? AppName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Duration { get; set; }
    }
}

namespace BlazorServerTemplate.Data
{
    public class BucketDuration
    {
        public BucketDuration(int startLogID, string? appName, string startTime, string endTime, int duration)
        {
            StartLogID = startLogID;
            AppName = appName;
            StartTime = DateTime.Parse(startTime);
            EndTime = DateTime.Parse(endTime);
            Duration = duration;
        }

        public int StartLogID { get; set; }
        public string? AppName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Duration { get; set; }
    }
}
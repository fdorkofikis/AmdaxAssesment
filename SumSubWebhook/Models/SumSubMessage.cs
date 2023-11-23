namespace SumSubWebhook.Models
{
    public class SumSubMessage
    {
        public string ApplicantId { get; set; }
        public string InspectionId { get; set; }
        public string CorrelationId { get; set; }
        public string? LevelName { get; set; }
        public string ExternalUserId { get; set; }
        public string Type { get; set; }
        public bool? SandboxMode { get; set; }
        public string ReviewStatus { get; set; }
        
        //map to format yyyy-MM-dd HH:mm:ss.fff
        public string CreatedAtMs { get; set; }
        public string? ApplicantType { get; set; }
        public ReviewResult? ReviewResult { get; set; }
        public ApplicantMember[]? ApplicantMemberOf { get; set; }
        public string? VideoIdentReviewStatus { get; set; }
        public string? ApplicantActionId { get; set; }
        public string? ExternalApplicantActionId { get; set; }
        public string? ClientId { get; set; }
    }
}

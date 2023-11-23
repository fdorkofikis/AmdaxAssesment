namespace SumSubWebhook.Models
{
    public class ReviewResult
    {
        public string? ModerationComment { get; set; }
        public string? ClientComment { get; set; }
        public ReviewAnswer ReviewAnswer { get; set; }
        public string[]? RejectLabels { get; set; }
        public string? ReviewRejectType { get; set; }
    }
}

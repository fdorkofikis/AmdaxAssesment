namespace SumSubWebhook.Models.Entities
{
    public class ApplicationEntity
    {
        public string ApplicantId { get; set; }
        public string CorrelationId { get; set; }

        public ReviewAnswer ReviewAnswer { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

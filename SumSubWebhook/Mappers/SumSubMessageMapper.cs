using SumSubWebhook.Models;
using SumSubWebhook.Models.Entities;

namespace SumSubWebhook.Mappers
{
    public static class SumSubMessageMapper
    {
        public static ApplicationEntity ToApplicationEntity(this SumSubMessage message)
        {
            return new ApplicationEntity
            {
                ApplicantId = message.ApplicantId,
                CorrelationId = message.CorrelationId,
                ReviewAnswer = message.ReviewResult?.ReviewAnswer is null ? ReviewAnswer.None : message.ReviewResult.ReviewAnswer
            };
        }
    }
}

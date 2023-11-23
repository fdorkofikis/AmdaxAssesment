using SumSubWebhook.Models;

namespace SumSubWebhook.Services
{
    public interface IApplicantProcessService
    {
        Task ProcessSumSubMessage(SumSubMessage message);
    }
}

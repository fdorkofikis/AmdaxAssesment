using SumSubWebhook.Models.Entities;

namespace SumSubWebhook.Repository
{
    public interface IApplicationRepository
    {
        Task SaveApplicationResults(ApplicationEntity application);
        Task UpdateApplicationResults(ApplicationEntity application);
    }
}

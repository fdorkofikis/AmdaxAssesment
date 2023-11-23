using SumSubWebhook.Exceptions;
using SumSubWebhook.Mappers;
using SumSubWebhook.Models;
using SumSubWebhook.Repository;

using WebHookType = SumSubWebhook.Globals.Constants.WebHookTypes;

namespace SumSubWebhook.Services
{
    public class ApplicantProcessService : IApplicantProcessService
    {
        private readonly IApplicationRepository _repository;

        public ApplicantProcessService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessSumSubMessage(SumSubMessage message)
        {

            switch (message.Type)
            {
                case WebHookType.ApplicantCreated:
                    await _repository.SaveApplicationResults(message.ToApplicationEntity());
                    break;
                case WebHookType.ApplicantReviewed:
                    if (message.ReviewResult is null)
                    {
                        throw new ValidationException(
                            $"{nameof(message.ReviewResult)} : Cannot be null for an message of type ApplicantReviewed");
                    }
                    await _repository.UpdateApplicationResults(message.ToApplicationEntity());
                    break;
            }
        }
    }
}

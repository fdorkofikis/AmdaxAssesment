using Moq;
using SumSubWebhook.Exceptions;
using SumSubWebhook.Models;
using SumSubWebhook.Models.Entities;
using SumSubWebhook.Repository;
using SumSubWebhook.Services;

namespace SumSubWebhook.Tests
{
    public class ApplicantProcessServiceTests
    {
        [Fact]
        public async Task ProcessSumSubMessage_WhenWebHookTypeIsApplicantCreated_ThenSaveApplicationResults()
        {
            // ARRANGE
            var mock = new Mock<IApplicationRepository>();
            var service = new ApplicantProcessService(mock.Object);

            var message = new SumSubMessage{ Type = "applicantCreated" };

            // ACT
            await service.ProcessSumSubMessage(message);

            // ASSERT
            mock.Verify(x => x.SaveApplicationResults(It.IsAny<ApplicationEntity>()), Times.Once());

        }

        [Fact]
        public async Task ProcessSumSubMessage_WhenWebHookTypeIsApplicantReviewedAndReviewResultNull_ThenThrowValidationException()
        {
            // ARRANGE
            var mock = new Mock<IApplicationRepository>();
            var service = new ApplicantProcessService(mock.Object);

            var message = new SumSubMessage { Type = "applicantReviewed" };

            // ACT - Assert
            await Assert.ThrowsAnyAsync<ValidationException>(() => service.ProcessSumSubMessage(message));

        }

        [Fact]
        public async Task ProcessSumSubMessage_WhenWebHookTypeIsApplicantReviewed_ThenUpdateApplicationResults()
        {
            // ARRANGE
            var mock = new Mock<IApplicationRepository>();
            var service = new ApplicantProcessService(mock.Object);

            var message = new SumSubMessage { Type = "applicantReviewed" , ReviewResult = new ReviewResult { ReviewAnswer = ReviewAnswer.GREEN} };

            // ACT
            await service.ProcessSumSubMessage(message);

            // ASSERT
            mock.Verify(x => x.UpdateApplicationResults(It.IsAny<ApplicationEntity>()), Times.Once());
        }
    }
}
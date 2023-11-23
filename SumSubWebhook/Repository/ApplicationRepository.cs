using Microsoft.EntityFrameworkCore;
using SumSubWebhook.Exceptions;
using SumSubWebhook.Models.Entities;

namespace SumSubWebhook.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveApplicationResults(ApplicationEntity application)
        {
            application.Created = DateTime.UtcNow;
            _dbContext.Applications.Add(application);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateApplicationResults(ApplicationEntity application)
        {
            var applicationEntity = await _dbContext.Applications.FirstOrDefaultAsync(a => a.ApplicantId == application.ApplicantId);
            if (applicationEntity == null)
                throw new DataBaseException($"Could not find an application for ApplicantId: {application.ApplicantId}");

            applicationEntity.ReviewAnswer = application.ReviewAnswer;
            applicationEntity.Updated = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}

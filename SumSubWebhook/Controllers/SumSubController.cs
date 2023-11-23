using Microsoft.AspNetCore.Mvc;
using SumSubWebhook.Exceptions;
using SumSubWebhook.Models;
using SumSubWebhook.Services;

namespace SumSubWebhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumSubController : ControllerBase
    {
        private readonly IApplicantProcessService _applicantProcessService;
        private readonly ILogger _logger;

        public SumSubController(IApplicantProcessService service, ILogger<SumSubController> logger)
        {
            _applicantProcessService = service;
            _logger = logger;
        }

        [HttpPost("SumSubWebHook")]
        public async Task<IActionResult> SumSubWebHook(SumSubMessage message)
        {
            try
            {
                ValidateMessage(message);
                _logger.LogInformation(
                    $"Message received for ApplicantId: {message.ApplicantId} and CorrelationId: {message.CorrelationId} at {DateTime.Now}.");
                await _applicantProcessService.ProcessSumSubMessage(message);
                _logger.LogInformation($"Message for ApplicantId: {message.ApplicantId} processed.");
            }
            catch (DataBaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch ( ValidationException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("An unexpected exception happened", ex);
            }
            return Ok();
        }

        private static void ValidateMessage(SumSubMessage message)
        {
            if (message == null)
            {
                throw new ValidationException($"{nameof(message)} cannot be null");
            }
            if (string.IsNullOrEmpty(message.ApplicantId))
            {
                throw new ValidationException($"{nameof(message.ApplicantId)} cannot be null");
            }
            if (string.IsNullOrEmpty(message.CorrelationId))
            {
                throw new ValidationException($"{nameof(message.CorrelationId)} cannot be null");
            }
        }
    }
}
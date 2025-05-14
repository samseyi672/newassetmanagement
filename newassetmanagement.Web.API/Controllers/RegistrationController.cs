

namespace NewAsset.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IAssetCapitlInsuranceRegistrationService _assetCapitlInsuranceRegistrationService;

        public RegistrationController(IAssetCapitlInsuranceRegistrationService assetCapitlInsuranceRegistrationService)
        {
            _assetCapitlInsuranceRegistrationService = assetCapitlInsuranceRegistrationService;
        }

        /// <summary>
        /// Description: Registration endpoint for Asset Capital Insurance
        /// </summary>
        /// <param name="Request">Registration request payload</param>
        /// <returns>Returns 201 Created with registration response if successful; otherwise, appropriate error</returns>
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(AssetCapitalInsuranceRegistrationRequest Request)
        {
            var result = await _assetCapitlInsuranceRegistrationService.StartRegistration(Request);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(
                nameof(GetRegistrationByReference),
                new { reference = result.Data?.RequestReference },
                result);
        }

        /// <summary>
        /// Retrieves registration details by request reference.
        /// </summary>
        /// <param name="reference">The request reference returned during registration</param>
        /// <returns>Returns 200 OK with registration details if found; otherwise 404 Not Found</returns>
        [HttpGet("Registration/{reference}")]
        public async Task<IActionResult> GetRegistrationByReference(string reference)
        {
            var result = await _assetCapitlInsuranceRegistrationService.GetByReferenceAsync(reference);
            if (!result.Success || result.Data == null)
                return NotFound(GenericApiResponse<RegistrationResponse>.FailureResponse("Registration not found."));
            return Ok(result);
        }


    }
}

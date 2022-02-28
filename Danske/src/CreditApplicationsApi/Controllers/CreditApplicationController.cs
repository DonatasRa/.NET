using CreditApplicationsApi.Models;
using CreditApplicationsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CreditApplicationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditApplicationController : ControllerBase
    {
        private readonly CreditApplicationService _creditApplicationService;

        public CreditApplicationController(CreditApplicationService creditApplicationService)
        {
            _creditApplicationService = creditApplicationService;
        }

        [HttpPost]
        public IActionResult Apply(CreditApplication creditApplication)
        {
            try
            {
                var answer = _creditApplicationService.GetCreditAnswer(creditApplication);
                return Ok(answer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

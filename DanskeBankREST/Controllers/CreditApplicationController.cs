using DanskeBankREST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;


namespace DanskeBankREST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {

        private readonly ILogger<CreditApplicationController> _logger;

        public CreditApplicationController(ILogger<CreditApplicationController> logger)
        {
            _logger = logger;
        }

        // POST <CreditApplicationController>
        [HttpPost]
        public string Post(CreditApplication crAppl)
        {
            try
            {
                if (crAppl.AppliedAmount <= 0)
                {
                    return ("The field AppliedAmount must be bigger than 0.");
                }
                if (crAppl.PrevAmount < 0)
                {
                    return ("The field PrevAmount must be bigger or equal than 0.");
                }

                CreditDecision crDec = new CreditDecision
                {
                    Decision = crAppl.AppliedAmount >= 2000 && crAppl.AppliedAmount <= 69000
                };

                if (crDec.Decision)
                    if (crAppl.totalAmount > 60000) crDec.InterestRate = 6;
                    else if (crAppl.totalAmount >= 40000) crDec.InterestRate = 5;
                    else if (crAppl.totalAmount >= 20000) crDec.InterestRate = 4;
                    else crDec.InterestRate = 3;

                return JsonConvert.SerializeObject(crDec);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                throw;
            }
        }

    }
}

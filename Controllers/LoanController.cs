using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoanService.Controllers
{
   
    //[Route("api/[controller]")]
    //[ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private IConfiguration _config;
        public LoanController(ILogger<LoanController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost(nameof(LoanCreation))]
        [Authorize]
        public RespLoanCreation LoanCreation([FromBody] ReqLoanCreation data)
        {
            var response = new RespLoanCreation();

            //Validate the inputs
            //For ProductId, CustomerId and ShopId database validation would be required for the full implementation

            if (data.ProductId == null)
            {
                response.ResponseCode = "01";
                response.ResponseMessage = "Product ID cannot be null";
            }
            else if (data.CustomerId == null)
            {
                response.ResponseCode = "02";
                response.ResponseMessage = "Customer ID cannot be null";
            }
            else if (data.ShopId == null)
            {
                response.ResponseCode = "03";
                response.ResponseMessage = "Shop ID cannot be null";
            }
            else if (data.TotalLoanAmount <= 0)
            {
                response.ResponseCode = "04";
                response.ResponseMessage = "Total loan amount must be greater than 0";
            }
            else if (data.DailyRate <= 0)
            {
                response.ResponseCode = "05";
                response.ResponseMessage = "Daily rate must be greater than 0";
            }

            //To do
            //validate if the customer has an active loan 




            //To do
            //submit loan request
            //The call to the class to implement Submission of the loan requests will be made here



            //The response is returned here
            return response;
        }
              
    }
}

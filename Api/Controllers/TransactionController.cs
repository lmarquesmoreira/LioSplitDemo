using Microsoft.AspNetCore.Mvc;
using Api.Domain;
using Api.Services.Interfaces;
using Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly ISplitService _splitService;

        public TransactionController(ISplitService splitService)
        {
            _splitService = splitService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionModel transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }
            try
            {

                var model = new Transaction()
                {
                    Amount = transaction.Amount,
                    Order = JsonConvert.SerializeObject(transaction.Order),
                    CreatedOn = DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss")
                };

                var result = await _splitService.CreateTransaction(model, transaction.Sellers);

                return Ok(new
                {
                    operationResult = result,
                    data = transaction
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    operationResult = false,
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _splitService.GetTransactions();

                return Ok(new
                {
                    operationResult = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    operationResult = false,
                    error = ex.Message
                });
            }
        }

        [HttpPost("seller")]
        public async Task<IActionResult> SaveSeller([FromBody] Seller seller)
        {
            if(seller == null)
            {
                return BadRequest();
            }

            try
            {
                var model = new Seller
                {
                    Id = seller.Id,
                    Mdr = seller.Mdr,
                    CreatedOn = DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss"),
                    UpdatedOn = DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss")
                };
                var result = await _splitService.CreateSeller(model);
                return Ok(new
                {
                    operationResult = result,
                    data = seller
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    operationResult = false,
                    error = ex.Message
                });
            }            
        }
    }
}
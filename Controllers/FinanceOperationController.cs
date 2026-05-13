using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceOperationController : ControllerBase
    {
        private readonly IFinanceOperationService _financeService;

        public FinanceOperationController(
            IFinanceOperationService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceOperation>>> GetOperations()
        {
            var operations = await _financeService.GetAllAsync();

            return Ok(operations);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(
            FinanceOperation operation)
        {
            try
            {
                await _financeService.DepositAsync(operation);

                return Ok(new
                {
                    message = "Depósito realizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(
            FinanceOperation operation)
        {
            try
            {
                await _financeService.WithdrawAsync(operation);

                return Ok(new
                {
                    message = "Saque realizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
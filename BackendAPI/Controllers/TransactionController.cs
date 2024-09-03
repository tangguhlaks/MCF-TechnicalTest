using BackendAPI.Data;
using BackendAPI.Repository;
using BackendAPI.Response;
using BackendAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionRepositroy _transactionRepositroy;
        public TransactionController(ITransactionRepositroy masterRepositroy)
        {
            _transactionRepositroy = masterRepositroy;
        }

        [HttpPost("CreateBpkb")]
        public async Task<IActionResult> CreateBpkb([FromBody] Bpkb request)
        {
            BaseResponse<Bpkb> response = new BaseResponse<Bpkb>(); 
            try
            {
                response.code = 200;
                response.message = _transactionRepositroy.CreateBpkb(request);
                response.data = null;
                return Ok(response);
            }catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
                response.data = null;
                return Ok(response);
            }
        }

        [HttpGet("GetBpkbByAgreementNumber")]
        public async Task<IActionResult> GetBpkbByAgreementNumber(string agreementNumber)
        {
            BaseResponse<Bpkb> response = new BaseResponse<Bpkb>();
            try
            {
                response.code = 200;
                response.message = "success";
                response.data = _transactionRepositroy.GetBpkbByAgreementNumber(agreementNumber);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
                response.data = null;
                return Ok(response);
            }
        }

        [HttpGet("GetBpkb")]
        public async Task<IActionResult> GetBpkb()
        {
            BaseResponse<List<BpkbVM>> response = new BaseResponse<List<BpkbVM>>();
            try
            {
                response.code = 200;
                response.message = "success";
                response.data = _transactionRepositroy.GetBpkb();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
                response.data = null;
                return Ok(response);
            }
        }

        [HttpPut("UpdateBpkb")]
        public async Task<IActionResult> UpdateBpkb([FromBody] Bpkb request)
        {
            BaseResponse<Bpkb> response = new BaseResponse<Bpkb>();
            try
            {
                response.code = 200;
                response.message = _transactionRepositroy.UpdateBpkb(request);
                response.data = null;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
                response.data = null;
                return Ok(response);
            }
        }

        [HttpDelete("DeleteBpkb")]
        public async Task<IActionResult> DeleteBpkb(string agreementNumber)
        {
            BaseResponse<Bpkb> response = new BaseResponse<Bpkb>();
            try
            {
                response.code = 200;
                response.message = _transactionRepositroy.DeleteBpkb(agreementNumber) ? "success":"false";
                response.data = null;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
                response.data = null;
                return Ok(response);
            }
        }
    }
}

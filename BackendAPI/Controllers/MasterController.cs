using BackendAPI.Data;
using BackendAPI.Repository;
using BackendAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private IMasterRepositroy _masterRepositroy;
        public MasterController(IMasterRepositroy masterRepositroy)
        {
            _masterRepositroy = masterRepositroy;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult> Auth(string username, string password)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            try
            {
                response.code = 200;
                User user = _masterRepositroy.GetUserByUsername(username);
                if (user == null)
                {
                    response.message = "User Not Found!";
                    response.data = null;
                }
                else
                {
                    if (!user.password.Equals(password))
                    {
                        response.message = "Wrong Password!";
                        response.data = null;
                    }
                    else
                    {
                        if (!user.is_active)
                        {
                            response.message = "User Account is Not Active!";
                            response.data = null;
                        }
                        else
                        {
                            response.message = "Login Success";
                            response.data = user;
                            
                        }
                    }
                }
                return Ok(response);

            }catch (Exception ex)
            {
                response.data = null;
                response.code = 500;
                response.message = ex.Message;
                return Ok(response);
            }
        }

        [HttpGet("GetStorageLocation")]
        public async Task<ActionResult> GetStorageLocation()
        {
            BaseResponse<List<StorageLocation>> response = new BaseResponse<List<StorageLocation>>();
            try
            {
                response.code = 200;
                response.message = "";
                response.data = _masterRepositroy.GetStorageLocation();
                return Ok(response);
            }catch(Exception ex)
            {
                response.data = null;
                response.code = 500;
                response.message = ex.Message;
                return Ok(response);
            }
        }

        [HttpGet("GetStorageLocationByLocationId")]
        public async Task<ActionResult> GetStorageLocationByLocationId(string location_id)
        {
            BaseResponse<StorageLocation> response = new BaseResponse<StorageLocation>();
            try
            {
                response.code = 200;
                response.message = "";
                response.data = _masterRepositroy.GetStorageLocationById(location_id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.data = null;
                response.code = 500;
                response.message = ex.Message;
                return Ok(response);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/operations")]
    [ApiVersion("2.0")]
    public class Operations2Controller: ControllerBase
    {
        private IConfiguration _config;

        public Operations2Controller(IConfiguration config)
        {
            _config = config;

        }
        
        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok("api Version 2.0");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        
        [HttpOptions("memory")]
        public IActionResult ShowMemory()
        {
            try
            {                
                return Ok("200 MB Version 2");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}

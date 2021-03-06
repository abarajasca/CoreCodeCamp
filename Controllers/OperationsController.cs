﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class OperationsController: ControllerBase
    {
        private IConfiguration _config;

        public OperationsController(IConfiguration config)
        {
            _config = config;

        }
        
        [HttpOptions("reloadconfig")]
        [ApiVersion("1.0")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok("api Version 1.0");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpOptions("reloadconfig")]
        [ApiVersion("1.1")]
        public IActionResult ReloadConfig11()
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok("api Version 1.1");
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
                return Ok("200 MB");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}

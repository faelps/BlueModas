using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Response(string msg, int? id = null)
        {
            if (id != null || id > 0)
            {
                return Ok(new
                {
                    success = true,
                    message = msg
                });
            }

            return BadRequest(new
            {
                success = false,
                message = msg
            });
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")] /* http://localhost:5000/api/commands */
    [ApiController]
    public class CommandsController:ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>>GetString()
        {
            return new string[] {"this","is","hard","coded"};
        }
    }
}
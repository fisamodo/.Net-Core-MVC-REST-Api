using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")] /* http://localhost:5000/api/commands */
    [ApiController]
    public class CommandsController:ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context) => _context = context;

        //GET:     /api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }
        /*
        [HttpGet]
        public ActionResult<IEnumerable<string>>GetString()
        {
            return new string[] {"this","is","hard","coded"};
        }
        */    
    }
}
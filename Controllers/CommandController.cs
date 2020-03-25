using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       
        //GET:     api/commands/customId
        [HttpGet("{Id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var CommandItem = _context.CommandItems.Find(id);

            if(CommandItem==null)
            {
                return NotFound();
            }

            return CommandItem;
        }

        //POST:  /api/commands

        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command{Id=command.Id}, command);
        }

        //PUT:   /api/commands/n

        [HttpPut("{Id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
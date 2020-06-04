using Dynamic.Application.Events.Commands.CreateEvent;
using Dynamic.Application.Events.Commands.DeleteEvent;
using Dynamic.Application.Events.Commands.UpdateEvent;
using Dynamic.Application.Events.Queries.GetEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dynamic.WebUI.Controllers
{
    public class EventsController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<EventDto>> Get()
        {
            return await Mediator.Send(new GetEventsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEventCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEventCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEventCommand { Id = id });

            return NoContent();
        }
    }
}

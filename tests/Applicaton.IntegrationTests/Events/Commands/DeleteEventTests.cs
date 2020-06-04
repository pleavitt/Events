using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Events.Commands.CreateEvent;
using Dynamic.Application.Events.Commands.DeleteEvent;
using Dynamic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dynamic.Application.IntegrationTests.Events.Commands
{
  using static Testing;

  public class DeleteEventTests : TestBase
  {
    [Test]
    public void ShouldRequireValidEventId()
    {
      var command = new DeleteEventCommand { Id = 99 };

      FluentActions.Invoking(() =>
          SendAsync(command)).Should().Throw<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteEvent()
    {
      var eventId = await SendAsync(new CreateEventCommand
      {
        Name = "New Event"
      });

      await SendAsync(new DeleteEventCommand
      {
        Id = eventId
      });

      var testEvent = await FindAsync<Event>(eventId);

      testEvent.Should().BeNull();
    }
  }
}

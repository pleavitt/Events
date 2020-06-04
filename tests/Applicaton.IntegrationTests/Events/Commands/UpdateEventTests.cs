using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Events.Commands.CreateEvent;
using Dynamic.Application.Events.Commands.UpdateEvent;
using Dynamic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Dynamic.Application.IntegrationTests.Events.Commands
{
  using static Testing;

  public class UpdateEventTests : TestBase
  {
    [Test]
    public void ShouldRequireValidEventId()
    {
      var command = new UpdateEventCommand
      {
        Id = 99,
        Name = "New Name"
      };

      FluentActions.Invoking(() =>
          SendAsync(command)).Should().Throw<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueName()
    {
      var eventId = await SendAsync(new CreateEventCommand
      {
        Name = "New Event"
      });

      await SendAsync(new CreateEventCommand
      {
        Name = "Other Event"
      });

      var command = new UpdateEventCommand
      {
        Id = eventId,
        Name = "Other Event"
      };

      FluentActions.Invoking(() =>
          SendAsync(command))
              .Should().Throw<ValidationException>().Where(ex => ex.Errors.ContainsKey("Name"))
              .And.Errors["Name"].Should().Contain("The specified name is already exists.");
    }

    [Test]
    public async Task ShouldUpdateEvent()
    {
      var userId = await RunAsDefaultUserAsync();

      var eventId = await SendAsync(new CreateEventCommand
      {
        Name = "New Event"
      });

      var command = new UpdateEventCommand
      {
        Id = eventId,
        Name = "Updated Event Name"
      };

      await SendAsync(command);

      var list = await FindAsync<Event>(eventId);

      list.Name.Should().Be(command.Name);
      list.LastModifiedBy.Should().NotBeNull();
      list.LastModifiedBy.Should().Be(userId);
      list.LastModified.Should().NotBeNull();
      list.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
    }
  }
}

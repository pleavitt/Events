using Dynamic.Application.Common.Exceptions;
using Dynamic.Application.Events.Commands.CreateEvent;
using Dynamic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Dynamic.Application.IntegrationTests.Events.Commands
{
  using static Testing;

  public class CreateEventTests : TestBase
  {
    [Test]
    public void ShouldRequireMinimumFields()
    {
      var command = new CreateEventCommand();

      FluentActions.Invoking(() =>
          SendAsync(command)).Should().Throw<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueName()
    {
      await SendAsync(new CreateEventCommand
      {
        Name = "State of Origin"
      });

      var command = new CreateEventCommand
      {
        Name = "State of Origin"
      };

      FluentActions.Invoking(() =>
          SendAsync(command)).Should().Throw<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateEvent()
    {
      var userId = await RunAsDefaultUserAsync();

      var command = new CreateEventCommand
      {
        Name = "Halloween"
      };

      var id = await SendAsync(command);

      var testEvent = await FindAsync<Event>(id);

      testEvent.Should().NotBeNull();
      testEvent.Name.Should().Be(command.Name);
      testEvent.CreatedBy.Should().Be(userId);
      testEvent.Created.Should().BeCloseTo(DateTime.Now, 10000);

    }
  }
}

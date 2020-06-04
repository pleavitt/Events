using Dynamic.Application.Events.Queries.GetEvents;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dynamic.Application.IntegrationTests.Events.Queries
{
  using static Testing;

  public class GetEventsTests : TestBase
  {
    [Test]
    public async Task ShouldIncludePriorityLevels()
    {
      var query = new GetEventsQuery();

      var result = await SendAsync(query);

      result.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldGetAllListsAndItems()
    {
      var query = new GetEventsQuery();

      var result = await SendAsync(query);

      result.Should().HaveCount(0);
    }
  }
}

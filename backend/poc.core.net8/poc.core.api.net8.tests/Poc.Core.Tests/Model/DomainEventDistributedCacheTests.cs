using poc.core.api.net8.Model;

namespace poc.core.api.net8.tests.Model;

public class DomainEventDistributedCacheTests
{
    [Fact]
    public void Constructor_InitializesIdWithUniqueValue()
    {
        // Arrange & Act
        var cache1 = new DomainEventDistributedCache();
        var cache2 = new DomainEventDistributedCache();

        // Assert
        Assert.NotEqual(cache1.Id, cache2.Id);
    }

}

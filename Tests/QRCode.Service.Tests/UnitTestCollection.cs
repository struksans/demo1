using Xunit;

namespace QRCode.Service.Tests
{
    [CollectionDefinition("UnitTestCollection")]
    public class UnitTestCollection : ICollectionFixture<TestFixture> { }
}
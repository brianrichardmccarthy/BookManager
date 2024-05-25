using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace BookManagerApi.Integration.Tests.Helpers;

[SetUpFixture]
[ExcludeFromCodeCoverage]
public class TestHelper {
    public IServiceProvider ServiceProvider { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetUp() {
        throw new NotImplementedException();
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown() {
        throw new NotImplementedException();
    }
}
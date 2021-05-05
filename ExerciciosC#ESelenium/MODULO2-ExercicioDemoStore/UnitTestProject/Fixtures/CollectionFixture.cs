using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestProject.Fixtures
{
    [CollectionDefinition("GoogleChrome")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}

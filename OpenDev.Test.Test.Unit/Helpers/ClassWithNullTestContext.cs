using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithNullTestContext
    {
        public TestContext TestContext { get { return null; } set { } }
    }
}

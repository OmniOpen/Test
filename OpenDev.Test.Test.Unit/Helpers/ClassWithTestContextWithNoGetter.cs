using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithTestContextWithNoGetter
    {
        public TestContext TestContext { set { } }
    }
}

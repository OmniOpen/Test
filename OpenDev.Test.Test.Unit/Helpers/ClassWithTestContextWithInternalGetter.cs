using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithTestContextWithInternalGetter
    {
        public TestContext TestContext { internal get; set; }
    }
}

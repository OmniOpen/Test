using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithTestContextWithPrivateGetter
    {
        public TestContext TestContext { private get; set; }
    }
}

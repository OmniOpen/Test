using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithTestContextWithProtectedInternalGetter
    {
        public TestContext TestContext { protected internal get; set; }
    }
}

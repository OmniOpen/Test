using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithTestContextWithProtectedGetter
    {
        public TestContext TestContext { protected get; set; }
    }
}

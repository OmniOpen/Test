using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithInternalTestContextProperty
    {
        internal TestContext TestContext { get; set; }
    }
}

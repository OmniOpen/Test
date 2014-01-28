using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithPrivateTestContextProperty
    {
        private TestContext TestContext { get; set; }
    }
}

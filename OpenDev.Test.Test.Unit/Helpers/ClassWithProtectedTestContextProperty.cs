using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithProtectedTestContextProperty
    {
        protected TestContext TestContext { get; set; }
    }
}

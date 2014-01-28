using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace OmniOpen.Test.Test.Unit
{
    [TestClass]
    public class MSTestTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\OmniOpen.Test.Test.Unit.MSTestTests.xml", "TestData_InvokingClassesWithInvalidTestContextProperties", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\OmniOpen.Test.Test.Unit.MSTestTests.xml")]
        public void TestData_InvokingClassesWithInvalidTestContextProperties()
        {
            string testDescription = this.TestContext.DataRow["TestDescription"].ToString();
            object test = Activator.CreateInstance(Type.GetType(this.TestContext.DataRow["InvokingClass"].ToString()));
            string exceptionMessage = this.TestContext.DataRow["ExceptionMessage"].ToString();
            Action invocation;

            //arrange

            invocation = () => test.TestData<string>("TestDataColumn");

            //act & assert

            invocation.ShouldThrow<Exception>(testDescription)
                .WithMessage(exceptionMessage, testDescription);
        }

        [TestMethod]
        public void TestData_NullTestContext_ThrowsException()
        {
            Action invocation;
            Helpers.ClassWithNullTestContext test = new Helpers.ClassWithNullTestContext();

            //arrange

            invocation = () => test.TestData<string>("TestDataColumn");

            //act & assert

            invocation.ShouldThrow<Exception>("because the TestContext is null")
                .WithMessage("TestContext cannot be null");
        }

        [TestMethod]
        public void TestData_InvokingObjectIsNull_ThrowsException()
        {
            object test = null;
            Action invocation;

            //arrange

            invocation = () => test.TestData<string>("foo");

            //act & assert

            invocation.ShouldThrow<Exception>("because the invoking object is null")
                .WithMessage("Invoking object cannot be null");
        }

        [TestMethod]
        public void TestDataColumn_TestContextPropertyIsInvalidDataType_ThrowsException()
        {
            Helpers.ClassWithTestContextWithWrongDataType test = new Helpers.ClassWithTestContextWithWrongDataType();
            Action invocation;

            //arrange

            invocation = () => test.TestData<string>("foo");

            //act & assert

            invocation.ShouldThrow<Exception>("because the TestContext property is not a Microsoft.VisualStudio.TestTools.UnitTesting.TestContext")
                .WithMessage(string.Format(@"The TestContext property is not the required data type ""{0}"" but rather ""{1}""",
                                            typeof(TestContext).FullName,
                                            typeof(int).FullName));
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\OmniOpen.Test.Test.Unit.MSTestTests.xml", "TestData_RetrieveReferenceType", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\OmniOpen.Test.Test.Unit.MSTestTests.xml")]
        public void TestData_RetrieveReferenceType()
        {
            string actualTestData;

            //arrange

            //act

            actualTestData = this.TestData<string>("TestDataColumn");

            //assert

            actualTestData.Should().Be("Expected Test Data");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\OmniOpen.Test.Test.Unit.MSTestTests.xml", "TestData_RetrieveValueType", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\OmniOpen.Test.Test.Unit.MSTestTests.xml")]
        public void TestData_RetrieveValueType()
        {
            int actualTestData;

            //arrange

            //act

            actualTestData = this.TestData<int>("TestDataColumn");

            //assert

            actualTestData.Should().Be(1);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\OmniOpen.Test.Test.Unit.MSTestTests.xml", "TestData_RetrieveNullableTypeHavingAValue", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\OmniOpen.Test.Test.Unit.MSTestTests.xml")]
        public void TestData_RetrieveNullableTypeHavingAValue()
        {
            bool? actualTestData;

            //arrange

            //act

            actualTestData = this.TestData<bool?>("TestDataColumn");

            //assert

            actualTestData.Should().BeTrue();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\OmniOpen.Test.Test.Unit.MSTestTests.xml", "TestData_RetrieveNullableTypeHavingANullValue", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\OmniOpen.Test.Test.Unit.MSTestTests.xml")]
        public void TestData_RetrieveNullableTypeHavingANullValue()
        {
            if(!Convert.ToBoolean(this.TestContext.DataRow["IgnoreDataRow"]))
            {
                bool? actualTestData = null;

                //arrange

                //act

                actualTestData = this.TestData<bool?>("TestDataColumn");

                //assert

                actualTestData.Should().NotHaveValue();
            }
        }
    }
}

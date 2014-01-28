using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OmniOpen.Test
{
    public static class MSTest
    {
        public static TTestData TestData<TTestData>(this object @this, string testDataColumnName)
        {
            PropertyInfo testContextProperty;
            TestContext testContext;
            TTestData testData = default(TTestData);
            MethodInfo testContextPropertyGetter;
            object tempTestContext;

            //ensure the invoking object is not null
            if (@this == null) throw new Exception("Invoking object cannot be null");

            //ensure the TestContext property exists
            testContextProperty = @this.GetType().GetProperty("TestContext");
            if(testContextProperty == null)
            {
                throw new Exception(string.Format(@"Class ""{0}"" lacks required public property named ""TestContext""", @this.GetType().FullName));
            }

            //check that the TestContext property has a public getter

            testContextPropertyGetter = testContextProperty.GetGetMethod();
            if(testContextPropertyGetter == null)
            {
                throw new Exception(string.Format(@"Class ""{0}"" is required to have a ""TestContext"" property with a public getter but no public getter was found", @this.GetType().FullName));
            }

            tempTestContext = testContextPropertyGetter.Invoke(@this, null);

            //ensure the TestContext is a Microsoft.VisualStudio.TestTools.UnitTesting.TestContext            

            if (!typeof(TestContext).IsAssignableFrom(testContextPropertyGetter.ReturnType))
            {
                throw new Exception(string.Format(@"The TestContext Property is not the required data type ""{0}"" but rather ""{1}""",
                                                    typeof(TestContext).FullName,
                                                    tempTestContext.GetType().FullName));
            }

            //ensure the TestContext is not null

            if (tempTestContext == null)
            {
                throw new Exception("TestContext cannot be null");
            }
          

            testContext = tempTestContext as TestContext;

            if (testContext.DataRow[testDataColumnName] != DBNull.Value)
            {
                testData =
                    (TTestData) Convert.ChangeType(testContext.DataRow[testDataColumnName],
                                                    typeof(TTestData).IsGenericType ? typeof(TTestData).GetGenericArguments().First() : typeof(TTestData));
            }

            return testData;
        }
    }
}

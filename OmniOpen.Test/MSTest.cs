//  Copyright (C) 2014 Jerome Bell (jeromebell0509@gmail.com)
//
//  This file is part of OmniOpen Test.
//  OmniOpen Test is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  OmniOpen Test is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with OmniOpen Test.  If not, see <http://www.gnu.org/licenses/>.
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
    /// <summary>
    ///     Helper extension methods for writing MSTests
    /// </summary>
    public static class MSTest
    {
        /// <summary>
        ///     Retrieves the current data row's data for a data driven MSTest
        /// </summary>
        /// <typeparam name="TTestData">the data type of the retrieved data</typeparam>
        /// <param name="this">the invoking object (expected to be an MSTest)</param>
        /// <param name="testDataColumnName">the name of the desired data column of the current data row</param>
        /// <returns></returns>
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

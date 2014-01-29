Test
====

A library for boiler plate unit and integration test functionality

##Usage
```C#
[TestClass]
public class MyMSTest
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\MyMSTest.xml", "MyUnitTest", DataAccessMethod.Sequential)]
    [DeploymentItem(@"Data\MyMSTest.xml")]
    public void MyUnitTest()
    {
        bool? actualTestData;

        //arrange
        
        actualTestData = null;

        //act

        actualTestData = this.TestData<bool?>("TestDataColumn");

        //assert

        actualTestData.Should().BeTrue();
    }
}
```

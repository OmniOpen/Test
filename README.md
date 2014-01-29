Test
====

A library for boiler plate unit and integration test functionality

##Usage
The test library has an extension method for conveniently retrieving the current data row's data from a data driven MSTest.  If you were working with the following XML data source

```XML
<?xml version="1.0" encoding="utf-8" ?>
<Root>
    <MyUnitTest>
        <TheDividend>6</TheDividend>
        <TheDivisor>2</TheDivisor>
        <TheQuotient>3</TheQuotient>
    <MyUnitTest>
    
    <MyUnitTest>
        <TheDividend>10</TheDividend>
        <TheDivisor>5</TheDivisor>
        <TheQuotient>2</TheQuotient>
    <MyUnitTest>
</Root>
```

Then you would retrieve the values from this data source like the following

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
        int dividend;
        int divisor;
        int expectedQuotient;
        int actualQuotient;

        //arrange
        
        dividend = this.TestData<int>("TheDividend");           //first data row will be 6 and second will be 10
        divisor = this.TestData<int>("TheDivisor");             //first data row will be 2 and second will be 5
        expectedQuotient = this.TestData<int>("TheQuotient");   //first data row will be 3 and second will be 2
        
        //act

        actualQuotient = MathLib.Divide(dividend, divisor);

        //assert

        Assert.AreEqual(expectedQuotient, actualQuotient);
    }
}
```

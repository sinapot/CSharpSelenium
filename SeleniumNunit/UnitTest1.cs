namespace SeleniumNunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This test 1");

        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This test 2");

        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Teardown Method");

        }

    }
}
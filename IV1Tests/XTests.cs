using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using IV1;

namespace IV1.Tests
{
    public class ExternalI1 : I1
    {
        public void Print()
        {
            Trace.WriteLine("External I1");
        }
    }

    [TestClass()]
    public class XTests
    {
        [TestMethod()]
        public void SomethingTest()
        {
            IV1.XFactory.SetAlt(CreateType.Normal);
            var x1 = XFactory.Create();
            x1.Print();

            IV1.XFactory.SetAlt(CreateType.Alternative);
            var x2 = XFactory.Create();
            x2.Print();

            IV1.XFactory.SetAlt(CreateType.External);
            IV1.XFactory.ProvideAlt(typeof(ExternalI1));
            var x3 = XFactory.Create();
            x3.Print();

        }
    }
}
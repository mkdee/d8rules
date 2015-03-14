using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using drules.dates.library;
using drules.dates.library.rules;

namespace DateLibraryTest
{
    [TestFixture]
    public class DateLibraryPerformance
    {
        [Test]
        public void TestDateRuleSkipDaysRepeated()
        {
            // Flush one extract.   This will avoid the DB load lag from affecting the aserts
            DateExpression.Parse("skip(!(au.asx.nontrading | weekend),0)").GetDate(new DateTime(2011, 1, 24));


            DateTime startTime = DateTime.Now;
            DateTime endTime;

            System.Console.Out.WriteLine(startTime.ToLongTimeString());
            Assert.AreEqual(DateExpression.Parse("skip(!(au.asx.nontrading | weekend),0)").GetDate(new DateTime(2011, 1, 24)), new DateTime(2011, 1, 24));
            System.Console.Out.Write('\t');
            System.Console.Out.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);
            Assert.AreEqual(DateExpression.Parse("skip(!(au.asx.nontrading | weekend),2)").GetDate(new DateTime(2011, 1, 25)), new DateTime(2011, 1, 28));
            System.Console.Out.Write('\t');
            System.Console.Out.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);
            Assert.AreEqual(DateExpression.Parse("skip(!(au.asx.nontrading | weekend),2)").GetDate(new DateTime(2011, 1, 27)), new DateTime(2011, 1, 31));
            System.Console.Out.Write('\t');
            System.Console.Out.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);
            Assert.AreEqual(DateExpression.Parse("skip(!(au.asx.nontrading | weekend),-2)").GetDate(new DateTime(2011, 1, 27)), new DateTime(2011, 1, 24));
            System.Console.Out.Write('\t');
            System.Console.Out.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);
            Assert.AreEqual(DateExpression.Parse("skip(!(au.asx.nontrading | weekend),-2)").GetDate(new DateTime(2011, 1, 24)), new DateTime(2011, 1, 20));
            endTime = DateTime.Now;
            System.Console.Out.Write('\t');
            System.Console.Out.WriteLine(endTime.Subtract(startTime).TotalMilliseconds);

            Assert.LessOrEqual(endTime.Subtract(startTime).TotalMilliseconds, 60);
        }
    }
}

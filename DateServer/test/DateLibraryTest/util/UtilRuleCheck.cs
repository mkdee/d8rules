using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using drules.dates.library;
using NUnit.Framework;

namespace DateLibraryTest.util
{
    public static class UtilRuleCheck
    {
        public static void Validate(String ruleA, IDateRule ruleB, int depth)
        {
            Validate(DateExpression.Parse(ruleA), ruleB, depth);
        }

        public static void Validate(IDateRule ruleA, IDateRule ruleB, int depth)
        {
            IList<DateTime> datesA = new List<DateTime>(ruleA.GetDates(DateTime.Today, depth));
            IList<DateTime> datesB = new List<DateTime>(ruleB.GetDates(DateTime.Today, depth));

            Assert.AreEqual(datesA, datesB);

            foreach (var date in datesA)
                Console.WriteLine(date);
        }
    }
}

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
    public class DateLibraryTest
    {
        const int Testcases = 4 * 12;

        [Test]
        public void TestWeekday()
        {
            IDateRule rule = new DateRuleWeekday(DayOfWeek.Monday);

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Monday);
            }
        }

        [Test]
        public void TestOr()
        {
            IDateRule rule = new DateRuleOr(new IDateRule[] {new DateRuleWeekday(DayOfWeek.Saturday),
                                            new DateRuleWeekday(DayOfWeek.Sunday)});

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
            }
        }

        [Test]
        public void TestAnd()
        {
            IDateRule rule = new DateRuleAnd(new IDateRule[] {new DateRuleWeekday(DayOfWeek.Saturday),
                                            new DateRuleWildcard(null, 12, null)});

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Saturday && date.Month == 12);
            }
        }

        [Test]
        public void TestOrComplex()
        {
            IDateRule rule = new DateRuleOr(new IDateRule[] {new DateRuleWeekday(DayOfWeek.Saturday),
                                            new DateRuleWildcard(null, null, 15)});

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Saturday || date.Day == 15);
            }
        }


        [Test]
        public void TestWildcard()
        {
            IDateRule rule = new DateRuleWildcard(null, 1, 26);

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
                Assert.IsTrue(date.Month == 1 && date.Day == 26);
            }
        }

        /// <summary>
        /// This tests that a fixed date only returns one element
        /// </summary>
        [Test]
        public void TestWildcardFixed()
        {
			DateTime checkDate = new DateTime (2010, 1, 26);
			DateTime[] refDates = new DateTime[]{new DateTime(2010,1,1), new DateTime(2010,1,26), new DateTime(2010,2,1)};
			IDateRule rule = new DateRuleWildcard(checkDate.Year, checkDate.Month, checkDate.Day);

			foreach (var refDate in refDates)
				Assert.AreEqual ((refDate <= checkDate) ? 1 : 0, rule.GetDates (refDate, Testcases).Count ());
        }

        /// <summary>
        /// This tests the last day of the month logic
        /// </summary>
        [Test]
        public void TestWildcardLast()
        {
            IDateRule rule = new DateRuleWildcard(null, null);

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                Assert.IsTrue(date == new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)));
            }
        }


        [Test]
        public void TestDateRuleRoll()
        {
            // Third wednesday of each month
            const int rollNumber = 3;
            IDateRule rule = new DateRuleRoll(new DateRuleWildcard(null, null, 1), rollNumber,
                                              new DateRuleWeekday(DayOfWeek.Wednesday));

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {                
                DateTime backIn = date.AddDays(-7 * (rollNumber - 1));
                DateTime backOut = date.AddDays(-7 * (rollNumber));

                System.Console.Out.WriteLine(date);

                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Wednesday &&
                    (backIn.Month == date.Month && backIn.Year == date.Year) &&
                    (backOut.Month != date.Month));
            }
        }


        [Test]
        public void TestDateRuleSkipWhere()
        {
            DateTime maxDate = new DateTime(2010, 12, 31);
            DateTime[] validResults = new DateTime[]
                                          {
                                              new DateTime(2010, 12, 27),
                                              new DateTime(2010, 12, 28)
                                          };
            DateTime[] refdates = new DateTime[]
                                      {
                                          new DateTime(2010, 12, 1),
                                          new DateTime(2010, 12, 25),
                                          new DateTime(2010, 12, 26),
                                          new DateTime(2010, 12, 27),
                                          new DateTime(2010, 12, 28)                                          
                                      };

            IDateRule rule = new DateRuleSkipWhere(
                                                    new DateRuleOr(new IDateRule[]
                                                                      {
                                                                          new DateRuleWildcard(null, 12, 25),
                                                                          new DateRuleWildcard(null, 12, 26)
                                                                      }),
                                                   new DateRuleOr(new IDateRule[]
                                                                      {
                                                                          new DateRuleWeekday(DayOfWeek.Saturday),
                                                                          new DateRuleWeekday(DayOfWeek.Sunday)
                                                                      }), BusinessDayConvention.Following);
            foreach (var refdate in refdates)
            {
                DateTime temp = refdate;        // copy of ref date to avoid access modifier issue
                int count = 0;

                System.Console.Out.WriteLine(refdate);

                // Get the next two or less dates for the current year
                foreach (var date in rule.GetDates(refdate, 2).Where(date => date < maxDate))
                {
                    System.Console.Out.Write('\t');
                    System.Console.Out.WriteLine(date);
                    Assert.Contains(date, validResults);

                    count++;
                }

                Assert.AreEqual(validResults.Where(date => temp <= date).Count(), count);
            }
        }

        [Test]
        public void TestDateRuleEaster()
        {
            IDateRule rule = new DateRuleEaster();

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
            }
        }

        [Test]
        public void TestDateRollBackwards()
        {
            // Get the Second last wednesday for each month
            IDateRule rule = new DateRuleRoll(new DateRuleWildcard(null, null), -2,
                                              new DateRuleWeekday(DayOfWeek.Wednesday));

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                System.Console.Out.WriteLine(date);
            }
        }

        [Test]
        public void TestDateRollStartDates()
        {            
            IDateRule rule = new DateRuleRoll(new DateRuleWildcard(null, 3, 1), 2, new DateRuleWeekday(DayOfWeek.Monday));
            DateTime dateHoliday = new DateTime(2012,3,12);            

            for (DateTime date = new DateTime(2012,3,1); date < dateHoliday; )
            {
                DateTime result = rule.GetDate(date).Value;
                System.Console.Out.WriteLine(result);
                Assert.AreEqual(dateHoliday, result);

                date = date.AddDays(1);
            }
        }

        [Test]
        public void TestDateRuleNot()
        {
            IDateRule rule = new DateRuleNot(new DateRuleWeekday(DayOfWeek.Wednesday));

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                Assert.AreNotEqual(date.DayOfWeek, DayOfWeek.Wednesday);
                System.Console.Out.WriteLine(date);
            }
        }

        [Test]
        public void TestDateRuleNotNot()
        {
            IDateRule[] rules = new IDateRule[] {
                new DateRuleWeekday(DayOfWeek.Wednesday),
                new DateRuleNot(new DateRuleNot(new DateRuleWeekday(DayOfWeek.Wednesday)))};
            IEnumerator<DateTime>[] results = new IEnumerator<DateTime>[rules.Length];

            // initialise the results
            for (int i = 0; i < rules.Length; i++)
                results[i] = rules[i].GetDates(DateTime.Today, Testcases).GetEnumerator();

            for (int i = 0; i < Testcases; i++)
            {
                if (results[0].MoveNext() && results[1].MoveNext())
                {
                    Assert.AreEqual(results[0].Current, results[1].Current);
                    System.Console.Out.WriteLine(results[0].Current + " " + results[1].Current);
                }
                else Assert.Fail("Mismatch in result set length");
            }
        }

        [Test]
        public void TestDateRuleSkipDaysSimple()
        {
            IDateRule rule = DateExpression.Parse("!(au.asx.nontrading | weekend)");

            Assert.AreEqual(new DateRuleSkip(rule, 0).GetDate(new DateTime(2011, 1, 24)), new DateTime(2011, 1, 24));
            Assert.AreEqual(new DateRuleSkip(rule, 2).GetDate(new DateTime(2011, 1, 25)), new DateTime(2011, 1, 28));
            Assert.AreEqual(new DateRuleSkip(rule, 2).GetDate(new DateTime(2011, 1, 27)), new DateTime(2011, 1, 31));
            Assert.AreEqual(new DateRuleSkip(rule, -2).GetDate(new DateTime(2011, 1, 27)), new DateTime(2011, 1, 24));
            Assert.AreEqual(new DateRuleSkip(rule, -2).GetDate(new DateTime(2011, 1, 24)), new DateTime(2011, 1, 20));            
        }

        [Test]
        public void TestDateRuleMondayMarch()
        {
            IDateRule rule = DateExpression.Parse("mon & */3/*");

            foreach (var date in rule.GetDates(DateTime.Today, Testcases))
            {
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Monday && date.Month == 3);                
            }            
        }
    }
}

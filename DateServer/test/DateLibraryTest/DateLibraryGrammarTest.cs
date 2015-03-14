using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateLibraryTest.util;
using NUnit.Framework;

using drules.dates.library;
using drules.dates.library.grammar;
using drules.dates.library.rules;

namespace DateLibraryTest
{
    [TestFixture]    
    public class DateLibraryGrammarTest
    {
        private const int TestCases = 40;

        [Test]
        public void TestEaster()
        {
            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse("easter"),
                                        new DateRuleEaster()
                                    };
            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);
        }


        [Test]
        public void TestGrammarOr()
        {
            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse("su | sa"),
                                        new DateRuleOr(new IDateRule[]
                                                           {
                                                               new DateRuleWeekday(DayOfWeek.Saturday),
                                                               new DateRuleWeekday(DayOfWeek.Sunday)
                                                           })
                                    };

            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);
        }

        [Test]
        public void TestGrammarComplex()
        {
            // Below is the date rule for Australia's main holidays
            IDateRule rule = DateExpression.Parse("skip(*/1/1 | */1/26 | easter | */4/25 | */12/25 | */12/26, sa | su)");

            foreach (var date in rule.GetDatesBetween(DateTime.Today, DateTime.Today.AddYears(3)))
            {
                Console.WriteLine(date);
            }
            Assert.IsNotNull(rule);            
        }

        [Test]
        public void TestGrammarAssignments()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine("weekend = sa | su");
            buffer.AppendLine("holidays = */1/1 | */1/26 | easter | */4/25 | */12/25 | */12/26");
            buffer.AppendLine("skip(holidays, weekend)");

            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse(
                                            "skip(*/1/1 | */1/26 | easter | */4/25 | */12/25 | */12/26, sa | su)"),
                                        DateExpression.Parse(buffer.ToString())
                                    };
            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);
        }

        [Test]
        public void TestDateWildLast()
        {
            UtilRuleCheck.Validate("*/6/last | */12/last",
                new DateRuleOr(new IDateRule[] {new DateRuleWildcard(null, 6), new DateRuleWildcard(null, 12)}), TestCases);
        }

        [Test]
        public void TestGrammarRollback()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine("roll(*/*/last, -2, wed)");

            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse(buffer.ToString()),
                                        new DateRuleRoll(new DateRuleWildcard(null, null), -2,
                                                         new DateRuleWeekday(DayOfWeek.Wednesday))
                                    };
            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);
        }

        [Test]
        public void TestGrammarSimpleNot()
        {
            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse("!(wed)"),
                                        new DateRuleNot(new DateRuleWeekday(DayOfWeek.Wednesday))
                                    };

            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);            
        }

        [Test]
        public void TestGrammarComplexNot()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine("weekend = sa | su");
            buffer.AppendLine("holidays = */1/1 | */1/26 | easter | */4/25 | */12/25 | */12/26");
            buffer.AppendLine("non_trading = skip(holidays, weekend) | weekend");            
            buffer.AppendLine("roll(skip(*/*/*, weekend), 4, !(non_trading))");

            IDateRule rule = DateExpression.Parse(buffer.ToString());            

            foreach (var date in rule.GetDates(DateTime.Today, 48))
            {
                System.Console.Out.WriteLine(date);
            }
        }

        [Test]
        public void TestGrammarSkipSimple()
        {
            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse("skip(!(au | weekend), 2)"),
                                        new DateRuleSkip(DateExpression.Parse("!(au | weekend)"), 2)
                                    };
            
            Assert.AreEqual(rules[0].GetDate(), rules[1].GetDate());                        
        }

        [Test]
        public void TestGrammarASXSettlement()
        {
            IDateRule rule = DateExpression.Parse("skip(!(au.asx.nonsettlement.chess | weekend), 3)");
            IDictionary<DateTime, DateTime> map = new Dictionary<DateTime, DateTime>();

            map.Add(new DateTime(2012,3,1), new DateTime(2012,3,6));
            map.Add(new DateTime(2012,3,2), new DateTime(2012,3,7));
            map.Add(new DateTime(2012,3,3), new DateTime(2012,3,7));
            map.Add(new DateTime(2012,3,4), new DateTime(2012,3,7));
            map.Add(new DateTime(2012,3,5), new DateTime(2012,3,8));
            map.Add(new DateTime(2012,3,6), new DateTime(2012,3,9));
            map.Add(new DateTime(2012,3,7), new DateTime(2012,3,13));
            map.Add(new DateTime(2012,3,8), new DateTime(2012,3,14));
            map.Add(new DateTime(2012,3,9), new DateTime(2012,3,15));
            map.Add(new DateTime(2012,3,10), new DateTime(2012,3,15));
            map.Add(new DateTime(2012,3,11), new DateTime(2012,3,15));
            map.Add(new DateTime(2012,3,12), new DateTime(2012,3,15));
            map.Add(new DateTime(2012,3,13), new DateTime(2012,3,16));
            map.Add(new DateTime(2012,3,14), new DateTime(2012,3,19));
            map.Add(new DateTime(2012,3,15), new DateTime(2012,3,20));
            map.Add(new DateTime(2012,4,2), new DateTime(2012,4,5));
            map.Add(new DateTime(2012,4,3), new DateTime(2012,4,10));
            map.Add(new DateTime(2012,4,4), new DateTime(2012,4,11));
            map.Add(new DateTime(2012,4,5), new DateTime(2012,4,12));
            map.Add(new DateTime(2012,4,6), new DateTime(2012,4,12));
            map.Add(new DateTime(2012,4,7), new DateTime(2012,4,12));
            map.Add(new DateTime(2012,4,8), new DateTime(2012,4,12));
            map.Add(new DateTime(2012,4,9), new DateTime(2012,4,12));
            map.Add(new DateTime(2012,4,10), new DateTime(2012,4,13));
            map.Add(new DateTime(2012,4,11), new DateTime(2012,4,16));
            map.Add(new DateTime(2012,4,12), new DateTime(2012,4,17));
            map.Add(new DateTime(2012,4,13), new DateTime(2012,4,18));

            ValidateResults(rule, map, false);
        }

        [Test]
        public void TestGrammarSkipZeroDay()
        {
            IDateRule[] rules = new IDateRule[]
                                    {
                                        DateExpression.Parse("skip(au.quantum, 0)"),
                                        DateExpression.Parse("au.quantum")
                                    };

            UtilRuleCheck.Validate(rules[0], rules[1], TestCases);            
        }

        [Test]
        public void TestGrammarQuantumAdvance()
        {
            IDateRule rule = DateExpression.Parse("skip(au.quantum, 1)");
            IDictionary<DateTime, DateTime> map = new Dictionary<DateTime, DateTime>();

            map.Add(new DateTime(2012,3,8), new DateTime(2012,3,9));
            map.Add(new DateTime(2012,3,9), new DateTime(2012,3,12));
            map.Add(new DateTime(2012, 3, 10), new DateTime(2012, 3, 12));
            map.Add(new DateTime(2012, 3, 11), new DateTime(2012, 3, 12));
            map.Add(new DateTime(2012, 3, 12), new DateTime(2012, 3, 13));
            map.Add(new DateTime(2012, 3, 13), new DateTime(2012, 3, 14));
            map.Add(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15));
            map.Add(new DateTime(2012, 3, 15), new DateTime(2012, 3, 16));
            map.Add(new DateTime(2012, 3, 16), new DateTime(2012, 3, 19));
            map.Add(new DateTime(2012, 3, 17), new DateTime(2012, 3, 19));
            map.Add(new DateTime(2012, 3, 18), new DateTime(2012, 3, 19));
            map.Add(new DateTime(2012, 3, 19), new DateTime(2012, 3, 20));
            map.Add(new DateTime(2012, 3, 20), new DateTime(2012, 3, 21));
            map.Add(new DateTime(2012, 3, 21), new DateTime(2012, 3, 22));
            map.Add(new DateTime(2012, 3, 22), new DateTime(2012, 3, 23));
            map.Add(new DateTime(2012, 3, 23), new DateTime(2012, 3, 26));
            map.Add(new DateTime(2012, 4, 2), new DateTime(2012, 4, 3));
            map.Add(new DateTime(2012, 4, 3), new DateTime(2012, 4, 4));
            map.Add(new DateTime(2012, 4, 4), new DateTime(2012, 4, 5));
            map.Add(new DateTime(2012, 4, 5), new DateTime(2012, 4, 10));
            map.Add(new DateTime(2012, 4, 6), new DateTime(2012, 4, 10));
            map.Add(new DateTime(2012, 4, 7), new DateTime(2012, 4, 10));
            map.Add(new DateTime(2012, 4, 8), new DateTime(2012, 4, 10));
            map.Add(new DateTime(2012, 4, 9), new DateTime(2012, 4, 10));
            map.Add(new DateTime(2012, 4, 10), new DateTime(2012, 4, 11));
            map.Add(new DateTime(2012, 4, 11), new DateTime(2012, 4, 12));
            map.Add(new DateTime(2012, 4, 12), new DateTime(2012, 4, 13));

            ValidateResults(rule, map, false);
        }

        [Test]
        public void TestGrammarRollbackwards()
        {
//            IDateRule rule = DateExpression.Parse("au.asx.nontrading | au.vic | au.nsw | roll(*/8/1, 1, mon)");
            IDateRule rule = DateExpression.Parse("!(easter | weekend)");
            IDictionary<DateTime, DateTime> map = new Dictionary<DateTime, DateTime>();

            map.Add(new DateTime(2012, 4, 6), new DateTime(2012, 4, 5));
            map.Add(new DateTime(2012, 4, 9), new DateTime(2012, 4, 5));

            ValidateResults(rule, map, true);
        }

        [Test]
        public void TestGrammarIgnore()
        {            
            IDateRule rule = DateExpression.Parse(@"invalid = 2012/5/28
valid = !(invalid)
special_holidays = 2011/4/29 | 2012/6/5 | 2012/6/4
holidays_base = */1/1 | easter | roll(*/5/1, 1, mon) | roll(*/5/last, -1, mon) | roll(*/8/last, -1, mon) | */12/25 | */12/26
holidays = valid & holidays_base
skip(holidays | special_holidays, weekend)");
            IList<DateTime> validSet = new List<DateTime>();
            validSet.Add(new DateTime(2012,4,6));
            validSet.Add(new DateTime(2012,4,9));
            validSet.Add(new DateTime(2012,5,7));
            validSet.Add(new DateTime(2012,6,4));
            validSet.Add(new DateTime(2012,6,5));
            validSet.Add(new DateTime(2012,8,27));

            int i=0;
            foreach (var date in rule.GetDatesBetween(new DateTime(2012, 3, 21), new DateTime(2012, 9, 1)))
            {
                System.Console.Out.WriteLine(date);
                Assert.AreEqual(validSet[i++], date);
            }
        }

        private void ValidateResults(IDateRule rule, IDictionary<DateTime, DateTime> map, bool isBackwards)
        {
            foreach (var tuple in map)
            {
                var iterator = rule.Generate(tuple.Key, isBackwards).GetEnumerator();

                if (iterator.MoveNext())
                {
                    System.Console.Out.WriteLine(tuple.Key + "->" + iterator.Current + " " + tuple.Value);
                    Assert.AreEqual(tuple.Value, iterator.Current);
                }
                else Assert.Fail("Missing value");
            }
        }
    }
}

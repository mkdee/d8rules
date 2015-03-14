using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// Date Rule to calculate Easter
    /// </summary>    
    public class DateRuleEaster : AbstractDateRuleNamed
    {
        private static readonly int[] DateOffset = new[] { -2, 1 };
        private static readonly IDateRule Rule = new DateRuleEasterSunday();

        public override string Name
        {
            get { return "easter"; }
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            int direction = (isBackwards) ? -1 : 1;
            int bitmask = (isBackwards) ? 1 : 0;

            foreach (var date in Rule.Generate(refDate, isBackwards))
                for (int i = 0; i < 2; i++)
                {
                    DateTime result = date.AddDays(DateOffset[i ^ bitmask]);

                    if (result.CompareTo(refDate) * direction >= 0)
                        yield return result;
                }
        }

        #region Easter Sunday Date Rule
        private class DateRuleEasterSunday : AbstractDateRuleInfinite
        {
            protected override DateTime? GetNextDate(DateTime date, bool advanceEquals, int direction)
            {
                DateTime result = GetDate(date);
                int sign = Math.Sign(result.Year - date.Year) * direction;

                if (sign < 0 || sign == 0 && advanceEquals)
                    result = GetDate(date.AddYears(direction));

                return result;
            }

            private static DateTime GetDate(DateTime date)
            {
                return GetDate(date.Year);
            }

            private static DateTime GetDate(int year)
            {
                int a, b, c, d, e, f, g, h, i, k, l, m, p, q;

                DateTime result;

                if (year >= 1583)
                {
                    //Gregorian Calendar Easter 

                    Math.DivRem(year, 19, out a);
                    b = Math.DivRem(year, 100, out c);
                    d = Math.DivRem(b, 4, out e);
                    int temp;
                    f = Math.DivRem(b + 8, 25, out temp);
                    g = Math.DivRem(b - f + 1, 3, out temp);
                    Math.DivRem(19 * a + b - d - g + 15, 30, out h);
                    i = Math.DivRem(c, 4, out k);
                    Math.DivRem(32 + 2 * e + 2 * i - h - k, 7, out l);
                    m = Math.DivRem(a + 11 * h + 22 * l, 451, out temp);
                    p = Math.DivRem(h + l - 7 * m + 114, 31, out q);

                    result = new DateTime(year, p, q + 1);
                }
                else
                {
                    //Julian Calendar 

                    Math.DivRem(year, 4, out a);
                    Math.DivRem(year, 7, out b);
                    Math.DivRem(year, 19, out c);
                    Math.DivRem(19 * c + 15, 30, out d);
                    Math.DivRem(2 * a + 4 * b - d + 34, 7, out e);
                    f = Math.DivRem(d + e + 114, 31, out g);

                    result = new DateTime(year, f, g + 1);
                }

                return result;
            }
        }
        #endregion
    }
}

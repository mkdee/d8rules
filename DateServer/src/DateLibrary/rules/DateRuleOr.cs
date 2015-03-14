using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// Date Rule to join two date rules
    /// </summary>
    [NameDateRule("|")]
    public class DateRuleOr : AbstractDateRuleOperator
    {
        private const int Breaklimit = 0;

        public DateRuleOr(IEnumerable<IDateRule> rules)
            : base(rules)
        {
        }

        protected override bool IsInScope(int setsCount)
        {
            return setsCount > Breaklimit;
        }        

        protected override bool IsValidMatch(int subSetSize, int setsSize)
        {
            return (subSetSize > 0);
        }
    }
}

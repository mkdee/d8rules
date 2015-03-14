using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    [NameDateRule("&")]
    public class DateRuleAnd : AbstractDateRuleOperator
    {
        private const int Breaklimit = 1;

        public DateRuleAnd(IEnumerable<IDateRule> rules)
            : base(rules)
        {            
        }

        protected override bool IsInScope(int setsCount)
        {
            return setsCount > Breaklimit;
        }

        protected override bool IsValidMatch(int subSetSize, int setsSize)
        {
            return (subSetSize == setsSize);
        }
    }
}

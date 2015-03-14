using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    [NameDateRule("skip")]
    public class DateRuleSkip : AbstractDateRule, IDateRuleFunction
    {
        private readonly IDateRule _rule;        

        public DateRuleSkip(IDateRule rule, int count)
        {
            _rule = new DateRuleSkipItems(rule, count);
        }

        public DateRuleSkip(IDateRule rule, IDateRule skip)
            : this(rule, skip, BusinessDayConvention.Following)
        {                        
        }

        public DateRuleSkip(IDateRule rule, IDateRule skip, BusinessDayConvention convention)
        {
            _rule = new DateRuleSkipWhere(rule, skip, convention);
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate)
        {
            return _rule.Generate(refDate);
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            return _rule.Generate(refDate, isBackwards);            
        }
    }
}

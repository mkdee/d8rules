using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// DateRule to skip elements that exist in another set
    /// </summary>
    public class DateRuleSkipWhere : AbstractDateRule
    {        
        private readonly IDateRule _rule;
        
        public DateRuleSkipWhere(IDateRule rule, IDateRule skip)
            : this(rule, skip, BusinessDayConvention.Following)
        {            
        }

        public DateRuleSkipWhere(IDateRule rule, IDateRule skip, BusinessDayConvention convention)
        {
            if (BusinessDayConvention.Unadjusted == convention)
                _rule = rule;       // ignore the skip set
            else                               
                _rule = new DateRuleAdjust(rule, skip, convention);
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            return _rule.Generate(refDate, isBackwards);
        }
    }
}

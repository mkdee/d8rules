using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// Date rule to provide the complament set of dates
    /// </summary>
    public class DateRuleNot : AbstractDateRule
    {
        private readonly IDateRule _ruleExcept;
        private readonly IDateRule _rule;

        public DateRuleNot(IDateRule ruleExcept)
            : this(new DateRuleWildcard(null, null, null), ruleExcept)
        {            
        }

        private DateRuleNot(IDateRule rule, IDateRule ruleExcept)
        {
            /*
             * if the ruleExcept is of the same type, then
             * a not(not(rule)) is the same as rule.
             */ 
            DateRuleNot r = ruleExcept as DateRuleNot;

            if (null == r)
            {
                _rule = rule;
                _ruleExcept = ruleExcept;    
            } else {
                _rule = r._ruleExcept;      // Resulte is the same the underlying rule
                _ruleExcept = null;
            }
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            return (null == _ruleExcept) ? _rule.Generate(refDate, isBackwards) : GenerateInternal(refDate, isBackwards);
        }

        private IEnumerable<DateTime> GenerateInternal(DateTime refDate, bool isBackwards)
        {
            // Please note that we cannot use the Linc Except() function since the collections are infinite
            IEnumerator<DateTime> datesAll = _rule.Generate(refDate, isBackwards).GetEnumerator();
            IEnumerator<DateTime> datesExcept = _ruleExcept.Generate(refDate, isBackwards).GetEnumerator();
            int direction = (isBackwards) ? -1 : 1;
            bool hasExceptDates = datesExcept.MoveNext();

            while (datesAll.MoveNext())
            {
                bool isValid = true;

                if (hasExceptDates)
                {
                    while (hasExceptDates && datesAll.Current.CompareTo(datesExcept.Current) * direction > 0)
                        hasExceptDates = datesExcept.MoveNext();

                    if (hasExceptDates && datesAll.Current.CompareTo(datesExcept.Current) == 0)
                    {
                        isValid = false;
                        hasExceptDates = datesExcept.MoveNext();
                    }
                }

                if (isValid)
                    yield return datesAll.Current;
            }
        }
    }
}

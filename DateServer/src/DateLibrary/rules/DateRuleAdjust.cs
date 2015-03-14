using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// Class to adjust the intersecting dates and roll based on a selected convention
    /// </summary>
    public class DateRuleAdjust : AbstractDateRule
    {
        private static readonly IDictionary<BusinessDayConvention, BusinessDayConvention> MapConvention;

        private readonly IDateRule _rule;
        private readonly IDateRule _ruleSkip;
        private readonly IDateRule _ruleIntersectContinuous;
        private readonly IDateRule _ruleCandidates;
        private readonly BusinessDayConvention _convention;


        static DateRuleAdjust()
        {
            MapConvention = new Dictionary<BusinessDayConvention, BusinessDayConvention>
                                    {
                                        {BusinessDayConvention.ModifiedFollowing, BusinessDayConvention.Preceding},
                                        {BusinessDayConvention.ModifiedPreceding, BusinessDayConvention.Following}
                                    };
        }

        public DateRuleAdjust(IDateRule rule, IDateRule ruleSkip, BusinessDayConvention convention)
        {
            _rule = rule;
            _ruleSkip = ruleSkip;
            _ruleCandidates = new DateRuleNot(ruleSkip);
            _ruleIntersectContinuous = new DateRuleAndContinuous(new[] {_rule, _ruleSkip});
            _convention = convention;
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            IDictionary<DateTime, DateTime> map = new Dictionary<DateTime, DateTime>();
            DateTime startDate = GetPrevious(refDate, isBackwards).GetValueOrDefault(refDate);
            int direction = (isBackwards) ? -1 : 1;

            // Generate the dates for the main rule
            // and adjust them based on the valid dates and business day convention
            foreach (var date in _rule.Generate(startDate, isBackwards))
            {
                DateTime result = AdjustDate(date, _convention, map);

                if (result.CompareTo(refDate) * direction >= 0)
                    yield return result;
            }
        }

        /// <summary>
        /// Generate the first dates that have come from previous dates,
        /// but have bled through to the current reference date.
        /// For instance, skip(*/12/25 | */12/26, weekend)
        ///      if looking at monday 27-dec, it should be a holiday due
        ///      to xmas and boxing day falling on a saturday or sunday.            
        /// </summary>
        /// <param name="refDate"></param>
        /// <param name="isBackwards"></param>
        /// <returns></returns>
        private DateTime? GetPrevious(DateTime refDate, bool isBackwards)
        {
            DateTime? result = null;

            // we only need to include dates that may have bleed through,
            // if the convention has the same direction as the direction of the generate
            if (_convention != BusinessDayConvention.Unadjusted && isBackwards == IsBackwards(_convention))
            {
                var refDatesCheck = new LinkedList<DateTime>();
                int direction = (isBackwards) ? -1 : 1;
                IEnumerator<DateTime> prevSet = _ruleIntersectContinuous.Generate(refDate, !isBackwards).GetEnumerator();

                // go to start of previous continuous section
                while (prevSet.MoveNext())
                {
                    if ((refDatesCheck.Count == 0) || (refDatesCheck.First.Value.CompareTo(prevSet.Current) == direction))
                        refDatesCheck.AddFirst(prevSet.Current);
                    else
                        break;
                }

                if (refDatesCheck.Count > 0)
                    result = refDatesCheck.First.Value;
            }

            return result;
        }


        private DateTime AdjustDate(DateTime date, BusinessDayConvention convention, IDictionary<DateTime, DateTime> map)
        {
            DateTime result = date;

            if (convention != BusinessDayConvention.Unadjusted)
            {
                if (map.ContainsKey(result))
                    result = map[result];
                else
                {
                    IEnumerator<DateTime> validCandidates = _ruleCandidates.Generate(date, IsBackwards(convention)).Where(item => !map.Values.Contains(item)).GetEnumerator();

                    if (validCandidates.MoveNext())
                    {
                        if (validCandidates.Current != result)
                        {
                            // If modified, then adjust for month breaks
                            if ((validCandidates.Current.Month != date.Month) && MapConvention.ContainsKey(convention))
                                result = AdjustDate(date, MapConvention[convention], map);
                            else
                            {
                                result = validCandidates.Current;
                                map.Add(date, validCandidates.Current);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static bool IsBackwards(BusinessDayConvention convention)
        {
            return !(convention == BusinessDayConvention.Following || convention == BusinessDayConvention.ModifiedFollowing);
        }


        /// <summary>
        /// Private class to essentialy provide the same logic as AND but to also limit it to a continous set
        /// </summary>
        private class DateRuleAndContinuous : DateRuleAnd
        {
            private bool _isContinous = false;

            public DateRuleAndContinuous(IEnumerable<IDateRule> rules)
                : base(rules)
            {            
            }

            public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
            {
                _isContinous = true;
                return base.Generate(refDate, isBackwards);
            }

            protected override bool IsInScope(int setsCount)
            {
                return base.IsInScope(setsCount) && _isContinous;                
            }

            protected override bool IsValidMatch(int subSetSize, int setsSize)
            {
                bool result = base.IsValidMatch(subSetSize, setsSize);

                _isContinous &= result;
                return result;
            }
        }
    }
}
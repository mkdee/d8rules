using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// Date Rule to roll based on another rule
    /// </summary>
    [NameDateRule("roll")]
    public class DateRuleRoll : AbstractDateRule, IDateRuleFunction
    {
        private readonly IDateRule _ruleStart;
        private readonly int _number;
        private readonly IDateRule _ruleRoll;

        public DateRuleRoll(IDateRule ruleStart, int number, IDateRule ruleRoll)
        {
            _ruleStart = ruleStart;
            _number = number;
            _ruleRoll = ruleRoll;
        }

        public override IEnumerable<DateTime>  Generate(DateTime refDate, bool isBackwards)
        {
            bool rollBackwards = (_number < 0);
            bool hasSkips = (_number == 0);
            int skips = Math.Abs(_number) - 1;

            foreach (var date in _ruleStart.Generate(refDate, isBackwards))
            {
                IEnumerable<DateTime> set = _ruleRoll.Generate(date, rollBackwards);

                yield return (hasSkips ? set : set.Skip(skips)).First();
            }
        }
    }
}

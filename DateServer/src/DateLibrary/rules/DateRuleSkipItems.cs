using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    //ToDo: Look to rename or expose the skip(rule, n) as roll(rule, n)

    /// <summary>
    /// Date Rule to skip N elements
    /// </summary>
    public class DateRuleSkipItems : AbstractDateRule
    {
        private readonly IDateRule _rule;
        private readonly int _mod;
        private readonly bool _isBackwards;
        private readonly int _firstElement;

        public DateRuleSkipItems(IDateRule rule, int count)
        {
            _rule = rule;
            _isBackwards = (count < 0);
            _firstElement = Math.Sign(Math.Abs(count));
            _mod = Math.Max(1, Math.Abs(count));            
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate)
        {
            return Generate(refDate, _isBackwards);
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            var iteratorStart = _rule.Generate(refDate, !isBackwards).GetEnumerator();

            if (iteratorStart.MoveNext())
            {
                var iterator = _rule.Generate(iteratorStart.Current, isBackwards).GetEnumerator();

                for (int i = 0; iterator.MoveNext(); i++)
                {
                    if (i >= _firstElement && ((i % _mod) == 0))
                        yield return iterator.Current;
                }
            }
        }
    }
}

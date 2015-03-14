using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    /// <summary>
    /// Date Rule is an infinite set of dates
    /// </summary>
    public abstract class AbstractDateRuleInfinite : AbstractDateRule
    {
        protected delegate DateTime? GetNextDateDelegate(DateTime date, bool advanceEquals, int direction);

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            int direction = (isBackwards) ? -1 : 1;
            return Evaluate(refDate, direction, GetNextDate);
        }

        /// <summary>
        /// Returns an enumerable list of dates
        /// </summary>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <param name="direction">1 for forward.  -1 for backwards</param>
        /// <param name="next">lambda expression function</param>
        /// <returns>enumeration of dates</returns>
        private IEnumerable<DateTime> Evaluate(DateTime refDate, int direction, GetNextDateDelegate next)
        {
            DateTime? value = GetNextDate(refDate, false, direction);        // get the initial value                
            DateTime? prevValue = null;

            while (value.HasValue)
            {
                if (value.Equals(prevValue))
                    break;      // this prevents an infinite loop
                prevValue = value;

                yield return value.Value;
                value = next(value.Value, true, direction);
            }
        }

        protected abstract DateTime? GetNextDate(DateTime date, bool advanceEquals, int direction);
    }
}
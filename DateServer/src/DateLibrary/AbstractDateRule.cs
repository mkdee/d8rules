using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    public abstract class AbstractDateRule : IDateRule
    {
        /// <summary>
        /// Returns an enumerable list of dates
        /// </summary>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <returns>enumeration of dates</returns>
        public virtual IEnumerable<DateTime> Generate(DateTime refDate)
        {
            return Generate(refDate, false);
        }

        public abstract IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards);
    }
}

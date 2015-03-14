using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    public interface IDateRule
    {
        /// <summary>
        /// Returns an enumerable list of dates based on the reference date        
        /// </summary>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <returns>enumeration of dates</returns>
        IEnumerable<DateTime> Generate(DateTime refDate);

        /// <summary>
        /// Returns an enumerable list of dates based on the reference date
        /// </summary>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <param name="isBackwards">False for a forward list.  True for backwards</param>
        /// <returns>enumeration of dates</returns>
        IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards);
    }
}

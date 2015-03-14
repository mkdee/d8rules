using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    /// <summary>
    /// Enum of different business day conventions
    /// </summary>
    public enum BusinessDayConvention
    {
        // ISDA
        /// <summary>
        /// First business day after the given holiday.
        /// </summary>
        Following,
        /// <summary>
        /// First business day after the given holiday unless it belongs to a different month, in which case choose the first business day before the holiday.
        /// </summary>
        ModifiedFollowing,
        /// <summary>
        /// First business day before the given holiday.
        /// </summary>
        Preceding,

        // NON ISDA
        /// <summary>
        /// First business day before the given holiday unless it belongs to a different month, in which case choose the first business day after the holiday.
        /// </summary>
        ModifiedPreceding,
        /// <summary>
        /// No adjustments
        /// </summary>
        Unadjusted
    };
}

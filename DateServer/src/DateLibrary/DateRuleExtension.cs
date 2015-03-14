using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    /// <summary>
    /// Extension to date rules
    /// </summary>
    public static class DateRuleExtension
    {
        private const int Limit = 1000;


        /// <summary>
        /// Returns the first date for the rule for today
        /// </summary>
        /// <param name="rule">Rule to extend</param>
        /// <returns>A date or null</returns>
        public static DateTime? GetDate(this IDateRule rule)
        {            
            return rule.GetDate(DateTime.Today);
        }

        /// <summary>
        /// Returns the first date for the rule from the reference date
        /// </summary>
        /// <param name="rule">Rule to extend</param>
        /// <param name="refDate">Reference date</param>
        /// <returns>A date or null</returns>
        public static DateTime? GetDate(this IDateRule rule, DateTime refDate)
        {
            DateTime? result = null;

            foreach (var date in rule.Generate(refDate.Date))
            {
                result = date;
                break;
            }

            return result;
        }


        /// <summary>
        /// Returns an enumerable list of dates limited to 1000 elements
        /// </summary>
        /// <param name="rule">Rule to extend</param>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <returns>enumeration of dates</returns>
        public static IEnumerable<DateTime> GetDates(this IDateRule rule, DateTime refDate)
        {
            return rule.GetDates(refDate.Date, Limit); 
        }

        /// <summary>
        /// Returns an enumerable list of dates
        /// </summary>
        /// <param name="rule">Rule to extend</param>
        /// <param name="refDate">Starting initial/reference date</param>
        /// <param name="limit">Max number of elements</param>
        /// <returns>enumeration of dates</returns>
        public static IEnumerable<DateTime> GetDates(this IDateRule rule, DateTime refDate, int limit)
        {
            // Note that we call the generate rather than the GetDatesBetween method
            return rule.Generate(refDate.Date).Take(limit);
        }

        /// <summary>
        /// Returns an enumerable list of dates (limited to 1000 elements) between two dates
        /// </summary>
        /// <param name="rule">Rule to extend</param>
        /// <param name="fromRefDate">Starting initial/reference date</param>
        /// <param name="toRefDate">End date</param>
        /// <returns>enumeration of dates</returns>
        public static IEnumerable<DateTime> GetDatesBetween(this IDateRule rule, DateTime fromRefDate, DateTime toRefDate)
        {
            DateTime fromDate = fromRefDate.Date;
            DateTime toDate = toRefDate.Date;

            return rule.Generate(fromDate).TakeWhile(date => date <= toDate).Where(date => date >= fromDate);
        }
    }
}
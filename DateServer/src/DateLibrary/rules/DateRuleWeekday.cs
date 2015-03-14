using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// DateRule that handles weekdays
    /// </summary>
    public class DateRuleWeekday : AbstractDateRuleInfinite
    {
        private static readonly IDictionary<String, DayOfWeek> Map;
        private readonly DayOfWeek _weekday;

        static DateRuleWeekday()
        {
            Map = new Dictionary<string, DayOfWeek>();

            foreach (DayOfWeek value in Enum.GetValues(typeof(DayOfWeek)))            
                Map.Add(Enum.GetName(typeof(DayOfWeek), value), value);            
        }

        public DateRuleWeekday(DayOfWeek weekday)
        {
            _weekday = weekday;
        }

        protected override DateTime? GetNextDate(DateTime date, bool advanceEquals, int direction)
        {
            DateTime? result = null;

            int offset = (_weekday - date.DayOfWeek);        
       
            if (offset != 0 || advanceEquals)
                offset += ((direction*offset) <= 0) ? direction * 7 : 0;

            DateTime limit = ((direction > 0) ? DateTime.MaxValue : DateTime.MinValue).AddDays(-1 * offset);

            if (date.CompareTo(limit) * direction < 0)
                result = date.AddDays(offset);

            return result;                
        }

        public static bool TryPrase(String value, out IDateRule rule)
        {
            bool result = false;

            rule = null;
            if (value.Length > 1)
            {
                foreach (var item in Map.Where(item => item.Key.StartsWith(value, StringComparison.OrdinalIgnoreCase)))
                {
                    result = true;
                    rule = new DateRuleWeekday(item.Value);
                    break;
                }                
            }

            return result;
        }
    }
}

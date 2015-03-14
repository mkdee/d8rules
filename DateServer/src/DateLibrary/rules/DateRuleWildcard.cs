using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    /// <summary>
    /// DateRule that handles wildcards
    /// 
    /// ie */1/26 will be the 26th Jan in any year
    /// </summary>
    public class DateRuleWildcard : AbstractDateRuleInfinite
    {
        private readonly int? _year;
        private readonly int? _month;
        private readonly int? _day;
        private readonly bool _isLastDayOfMonth;
        private readonly DateTime _limitRangeStart;
        private readonly DateTime _limitRangeEnd;
        private readonly bool _isFixedDate;

        public DateRuleWildcard(int? year, int? month)
            : this(year, month, null, true)
        {            
        }

        public DateRuleWildcard(int? year, int? month, int? day)
            : this(year, month, day, false)
        {
        }

        private DateRuleWildcard(int? year, int? month, int? day, bool isLastDayOfMonth)            
        {            
            _year = year;
            _month = month;
            _day = day;            
            _isLastDayOfMonth = isLastDayOfMonth;

            int monthEnd = month.GetValueOrDefault(12);
            int yearEnd = year.GetValueOrDefault(DateTime.MaxValue.Year);

            _limitRangeStart = new DateTime(year.GetValueOrDefault(DateTime.MinValue.Year), month.GetValueOrDefault(1), day.GetValueOrDefault(1));
            _limitRangeEnd = new DateTime(yearEnd, monthEnd, day.GetValueOrDefault(DateTime.DaysInMonth(yearEnd, monthEnd)));
            _isFixedDate = (_limitRangeStart == _limitRangeEnd);                            
        }

        protected override DateTime?  GetNextDate(DateTime date, bool advanceEquals, int direction)
        {
            DateTime? result;

            if (_isFixedDate)
            {
				int sign = _limitRangeStart.CompareTo(date) * direction;

				result = ((sign == 0 & !advanceEquals) || sign > 0) ? _limitRangeStart : (DateTime?) null;
//				result = (advanceEquals) ? (DateTime?) null : _limitRangeStart;                
            }
            else
            {
                result = GetValidDate(date, direction);        // The resulting date can be prior to the date; please do not automatically advance these

                if (result.HasValue)
                {
//                    int sign = result.Value.CompareTo(date) * direction;

//                    if ((sign == 0 && advanceEquals) || sign < 0)
                    if (advanceEquals)
                        result = GetValidDate(GetNextDate(result.Value, direction), direction);                   
                }
            }

            return result;
        }

        private DateTime? GetNextDate(DateTime date, int direction)
        {
            DateTime? result = null;

            try
            {
                if (!_day.HasValue && !_isLastDayOfMonth)
                {
                    DateTime rollDate = new DateTime(date.Year, date.Month, (direction > 0) ? DateTime.DaysInMonth(date.Year, date.Month) : 1);

                    if (_month.HasValue && date.CompareTo(rollDate) == 0)
                        date = date.AddMonths(11 * direction);
                    result = date.AddDays(direction);         // need to know when to increase the month
                }                    
                else if (!_month.HasValue)
                    result = date.AddMonths(direction);       // need to know when to increase the year
                else if (!_year.HasValue)
                    result = date.AddYears(direction);                
            } catch (ArgumentOutOfRangeException) { }

            return result;
        }
        
        private DateTime? GetValidDate(DateTime? date, int direction)
        {
            return (date.HasValue) ? GetValidDate(date.Value, direction) : null;
        }

        private DateTime? GetValidDate(DateTime date, int direction)
        {
            int daysInMonth = DateTime.DaysInMonth(_year.GetValueOrDefault(date.Year),
                                                     _month.GetValueOrDefault(date.Month));
            if (!_day.HasValue && !_isLastDayOfMonth)
            {
                bool isForward = (direction > 0);
                DateTime checkDate = new DateTime(
                    _year.GetValueOrDefault(date.Year),
                    _month.GetValueOrDefault(date.Month),
                    (isForward) ? 1 : daysInMonth);

                if ((date < checkDate & isForward) |
                    (date > checkDate & !isForward))
                    return checkDate;
            }

            DateTime result = new DateTime(
                _year.GetValueOrDefault(date.Year),
                _month.GetValueOrDefault(date.Month),
                (_isLastDayOfMonth) ? daysInMonth : Math.Min(daysInMonth, _day.GetValueOrDefault(date.Day)));

            return (_limitRangeStart <= result && result <= _limitRangeEnd) ? (DateTime?) result : null;
        }
    }

    /// <summary>
    /// IntWild class to 
    /// </summary>
    public static class IntWild
    {
        public static int? Parse(String value)
        {
            int? result = null;
            int i;

            if (value != "*" && int.TryParse(value, out i))
                result = i;

            return result;
        }
    }    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace drules.dates.library.rules
{
    public class DateRuleLazy : IDateRule  
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DateRuleLazy));
        private static readonly DateTime[] ResultEmpty = new DateTime[0];

        private IDateRule _rule;
        private bool _isInitialised;
        private String _ruleExpression;

        public DateRuleLazy(String ruleExpression)
        {
            _ruleExpression = ruleExpression;
        }

        #region IDateRule Members

        public IEnumerable<DateTime> Generate(DateTime refDate)
        {
            IDateRule rule = Rule;

            return (null == rule) ? ResultEmpty : rule.Generate(refDate);                
        }

        public IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            IDateRule rule = Rule;

            return (null == rule) ? ResultEmpty : rule.Generate(refDate, isBackwards);            
        }

        #endregion

        private IDateRule Rule
        {
            get
            {
                if (!_isInitialised)
                {
                    try
                    {
                        _rule = DateExpression.Parse(_ruleExpression);    
                    } catch(Exception ex)
                    {
                        Logger.Error("Error parsing " + _ruleExpression, ex);
                    }
                    _isInitialised = true;
                }

                return _rule;
            }
        }
    }
}

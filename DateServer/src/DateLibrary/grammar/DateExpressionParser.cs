using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using drules.dates.library.rules;

namespace drules.dates.library.grammar
{
    public partial class DateExpressionParser
    {
        readonly private IDictionary<String, IDateRule> _mapRulesLocal = new Dictionary<string, IDateRule>();

        public IDateRule Expression
        {
            get
            {
                IDateRule result = this.statement().result;

                return result;
            }
        }

        private void AddRule(String input, IDateRule rule)
        {
            String name = input.ToLower();

            if (!_mapRulesLocal.ContainsKey(name))
                _mapRulesLocal.Add(name, rule);
        }

        #region Activators for Rules
        private IDateRule GetRule(String input)
        {
            String name = input.ToLower();
            IDateRule result = null;

            if (_mapRulesLocal.ContainsKey(name))
                result = _mapRulesLocal[name];
            else
            {
                if (DateExpression.Instance.MapRules.ContainsKey(name))
                    result = DateExpression.Instance.MapRules[name];
                else
                    DateRuleWeekday.TryPrase(input, out result);    
            }            

            return result;
        }

        private IDateRule GetRule(String input, IEnumerable<Object> args)
        {
            IDateRule result = null;

            if (null == args)
                result = GetRule(input);
            else
            {
                String name = input.ToLower();

                if (DateExpression.Instance.MapFunctions.ContainsKey(name))
                {
                    Object[] values = new List<object>(args).ToArray();

                    result = Activator.CreateInstance(DateExpression.Instance.MapFunctions[name], values) as IDateRule;
                }
            }

            return result;
        }

        private IDateRule GetOperator(String input, IEnumerable<IDateRule> args)
        {
            String name = input.ToLower();
            IDateRule result = null;

            if (DateExpression.Instance.MapOperators.ContainsKey(name))
                result = Activator.CreateInstance(DateExpression.Instance.MapOperators[name], new object[] { args }) as IDateRule;

            return result;
        }
        #endregion
    }
}

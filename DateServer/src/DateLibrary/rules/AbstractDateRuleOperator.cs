using System;
using System.Collections.Generic;
using System.Linq;

namespace drules.dates.library.rules
{
    public abstract class AbstractDateRuleOperator : AbstractDateRule, IDateRuleOperator
    {
        private readonly IEnumerable<IDateRule> _rules;

        protected AbstractDateRuleOperator(IEnumerable<IDateRule> rules)
        {
            _rules = rules;
        }

        public override IEnumerable<DateTime> Generate(DateTime refDate, bool isBackwards)
        {
            ICollection<IEnumerator<DateTime>> sets = new List<IEnumerator<DateTime>>();
            Func<ICollection<IEnumerator<DateTime>>, DateTime> func = (isBackwards) ? s => s.Max(item => item.Current) : func = s => s.Min(item => item.Current);             

            // initialise the sets that we are working on;
            foreach (var rule in _rules)
            {                
                IEnumerator<DateTime> iterator = rule.Generate(refDate, isBackwards).GetEnumerator();

                if (iterator.MoveNext())
                    sets.Add(iterator);
            }

            // While there is something in the collection of sets
            while (IsInScope(sets.Count))
            {
                var date = func(sets);
                ICollection<IEnumerator<DateTime>> subset = new List<IEnumerator<DateTime>>(sets.Where(item => item.Current == date));

                if (IsValidMatch(subset.Count(), sets.Count))                    
                    yield return date;

                foreach (var set in subset)
                {                    
                    if (!set.MoveNext())   // if there is nothing left in the collection                                                
                        sets.Remove(set);                        
                }                    
            }
        }

        protected abstract bool IsValidMatch(int subSetSize, int setsSize);
        protected abstract bool IsInScope(int setsCount);
    }
}

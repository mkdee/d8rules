using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library.rules
{
    public abstract class AbstractDateRuleNamed : AbstractDateRule, IDateRuleNamed
    {
        abstract public string Name { get; }
    }
}

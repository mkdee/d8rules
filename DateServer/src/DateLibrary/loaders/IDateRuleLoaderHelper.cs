using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace drules.dates.library.loaders
{
    [InheritedExport]
    public interface IDateRuleLoaderHelper
    {
        IEnumerable<KeyValuePair<String, IDateRule>> GetRules();
    }
}

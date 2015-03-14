using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using drules.dates.library.util;
using log4net;

namespace drules.dates.library.loaders
{
    public class DateRuleLoadAssembly : PluginLoader<IDateRuleNamed>, IDateRuleLoaderHelper
    {
        public DateRuleLoadAssembly()
            : base(new AssemblyCatalog(Assembly.GetExecutingAssembly()))
        {            
        }

        public IEnumerable<KeyValuePair<string, IDateRule>> GetRules()
        {
            IDictionary<String, IDateRule> result = new Dictionary<string, IDateRule>();

            foreach (var rule in Plugins)            
                result.Add(rule.Name, rule);

            return result;
        }
    }
}

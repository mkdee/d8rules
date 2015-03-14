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
    public class DateRuleLoader : PluginLoader<IDateRuleLoaderHelper>
    {
        private DateRuleLoader()
            : base(new AssemblyCatalog(Assembly.GetExecutingAssembly()))
        {            
        }

        public IEnumerable<KeyValuePair<String, IDateRule>> GetRules()
        {
            IDictionary<String, IDateRule> result = new Dictionary<string, IDateRule>();

            // Loop through the plug ins
            foreach (var plugin in Plugins)
            {
                foreach (var item in plugin.GetRules())                
                    result.Add(item);                
            }

            return result;
        }

        static public DateRuleLoader Instance
        {
            get
            {
                return Singleton<DateRuleLoader>.Instance;
            }
        }
    }
}

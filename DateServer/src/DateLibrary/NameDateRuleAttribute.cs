using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NameDateRuleAttribute : Attribute
    {        
        public string Name { get; private set; }        
        
        public NameDateRuleAttribute(String name)
        {
            Name = name;            
        }        
    }
}

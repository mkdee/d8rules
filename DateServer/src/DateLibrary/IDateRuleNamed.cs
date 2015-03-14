using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace drules.dates.library
{
    [InheritedExport]
    public interface IDateRuleNamed : IDateRule
    {
        string Name { get; }
    }
}
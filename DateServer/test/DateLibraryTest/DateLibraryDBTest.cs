using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateLibraryTest.util;
using drules.dates.library;
using NUnit.Framework;

namespace DateLibraryTest
{
    [TestFixture]    
    public class DateLibraryDbTest
    {
        [Test]
        public void TestSimpleLoad()
        {
            UtilRuleCheck.Validate("weekend", DateExpression.Parse("sa | su"), 40);            
        }
    }
}

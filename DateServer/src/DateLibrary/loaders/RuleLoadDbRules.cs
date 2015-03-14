using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using drules.dates.library.rules;

namespace drules.dates.library.loaders
{
    public class RuleLoadDbRules : AbstractRuleLoadDb
    {
        protected override string Command
        {
            get
            {
                return @"select s.Code, v.Value from vw_DateSet s INNER JOIN vw_DateSetRules v ON (s.ID = v.DateSetID)";
            }
        }

        protected override IEnumerable<KeyValuePair<string, IDateRule>> GetRules(System.Data.IDataReader reader)
        {
            IDictionary<String, IDateRule> result = new Dictionary<string, IDateRule>();

            while (reader.Read())            
                result.Add(reader[0].ToString(), new DateRuleLazy(reader[1].ToString()));                            

            return result;
        }
    }
}

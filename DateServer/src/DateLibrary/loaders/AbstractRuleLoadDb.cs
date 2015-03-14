using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Configuration;

using log4net;

using drules.dates.library.util;

namespace drules.dates.library.loaders
{
    public abstract class AbstractRuleLoadDb : IDateRuleLoaderHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AbstractRuleLoadDb));
        private static readonly String Provider;
        private static readonly String ConnectionString;

        static AbstractRuleLoadDb()
        {
            Logger.Info("Instanciating DatesServer...");
            String envState = Environment.GetEnvironmentVariable("Environ");
            String dsn = "Default";

            ConnectionStringSettingsCollection connectionStrings = UtilConfiguration.Default.ConnectionStrings.ConnectionStrings;

            if (!String.IsNullOrEmpty(envState))
                dsn = envState;
            dsn = "Reference" + dsn;
            
            Logger.Info("Connecting to " + dsn + "...");
            Provider = connectionStrings[dsn].ProviderName;
            Logger.Debug("\t" + Provider);            
            ConnectionString = connectionStrings[dsn].ConnectionString;
            Logger.Debug("\t" + ConnectionString);
        }

        protected abstract String Command { get; }

        public IEnumerable<KeyValuePair<string,IDateRule>> GetRules()
        {
            List<KeyValuePair<string, IDateRule>> result = new List<KeyValuePair<string, IDateRule>>();

 	        using (DbConnection connection = DbProviderFactories.GetFactory(Provider).CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = Command;

                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))                    
                        result.AddRange(GetRules(reader));                                            
                }
            }

            return result;
        }

        protected abstract IEnumerable<KeyValuePair<string, IDateRule>> GetRules(IDataReader reader);
    }
}

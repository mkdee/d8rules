using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

using drules.dates.library.loaders;
using log4net;
using Antlr.Runtime;

using drules.dates.library.grammar;
using drules.dates.library.util;


namespace drules.dates.library
{
    public class DateExpression
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DateExpression));
        private static readonly SimpleCache<String, IDateRule> Cache = new SimpleCache<String, IDateRule>(500, ParseNew);

        internal readonly IDictionary<String, Type> MapFunctions;
        internal readonly IDictionary<String, Type> MapOperators;

        private readonly IDictionary<String, IDateRule> _mapRules;        
        private readonly Timer _timer;


        private DateExpression()
        {
            int interval = 5;           // Default

            _mapRules = new Dictionary<String, IDateRule>();
            MapFunctions = new Dictionary<String, Type>();
            MapOperators = new Dictionary<String, Type>();

            Init();

            try
            {
                interval = int.Parse(UtilConfiguration.Default.AppSettings.Settings["PollInterval"].Value);                
            } catch(Exception ex)
            {
                Logger.Warn("Unable to get application setting", ex);
            }                            

            _timer = new Timer(Refresh, new AutoResetEvent(true), interval * 60 * 1000, interval * 60 * 1000);                                    
        }

        public static DateExpression Instance
        {
            get
            {
                return Singleton<DateExpression>.Instance;
            }
        }

        public static IDateRule Parse(String input)
        {
            return Cache.GetValue(input);
        }        

        private static IDateRule ParseNew(String input)
        {
            try
            {
                ANTLRStringStream stream = new ANTLRStringStream(input);
                DateExpressionLexer lexer = new DateExpressionLexer(stream);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                DateExpressionParser parser = new DateExpressionParser(tokens);                

                return parser.Expression;                
            }
            catch (Exception err)
            {
                throw err;
            }   
        }

        private void Init()
        {
            try
            {
                /*
                 * Custom plug-in loader
                 * 
                 * I use this code because the MEF framework required default contructors on the classes
                 */
                IDictionary<String, Type>[] maps = new[] { MapFunctions, MapOperators };
                Type[] mapTypes = new[] { typeof(IDateRuleFunction), typeof(IDateRuleOperator) };

                for (int i = 0; i < maps.Length; i++)
                {
                    foreach (var type in GetClassImplementingInterface(mapTypes[i]))
                    {
                        foreach (var item in type.GetCustomAttributes(typeof(NameDateRuleAttribute), false))
                        {
                            NameDateRuleAttribute attrib = item as NameDateRuleAttribute;

                            if (null != attrib)
                                maps[i].Add(attrib.Name, type);
                            break;
                        }
                    }
                }

                Refresh();
            }
            catch (Exception ex)
            {
                Logger.Fatal("Unable to import rules", ex);
            }   
        }        

        public void Refresh()
        {
            lock (_mapRules)
            {                
                _mapRules.Clear();
                foreach (var item in DateRuleLoader.Instance.GetRules())
                    _mapRules.Add(item);
            }            
        }

        private void Refresh(Object stateInfo)
        {
            Refresh();
        }

        internal IDictionary<String, IDateRule> MapRules
        {
            get
            {
                lock (_mapRules)
                {
                    return _mapRules;
                }
            }
        }

        public String[] RuleNames
        {
            get
            {
                return MapRules.Keys.ToArray();
            }
        }
                
        private static IEnumerable<Type> GetClassImplementingInterface(Type desiredType)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(
                t => (t.IsClass && !t.IsAbstract && desiredType.IsAssignableFrom(t))); 
        }            
    }
}
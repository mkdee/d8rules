using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;

namespace drules.dates.library.util
{
    abstract public class PluginLoader<T>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PluginLoader<T>));

        protected PluginLoader(ComposablePartCatalog catalog)
        {
            try
            {
                CompositionContainer container = new CompositionContainer(catalog);
                CompositionBatch batch = new CompositionBatch();

                batch.AddPart(this);
                container.Compose(batch);
            }
            catch (Exception ex)
            {
                Logger.Fatal("Unable to load plugins", ex);
            }          
        }

        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<T> Plugins
        {
            get; set;            
        }
    }
}

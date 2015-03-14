using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace drules.dates.library.util
{
    public static class UtilConfiguration
    {
        public static Configuration Default
        {
            get
            {
                Configuration result;
                HttpContext ctx = HttpContext.Current;    //WCF services hosted in IIS...
                VirtualPathExtension path = null;

                try
                {
                    if (null != OperationContext.Current)
                        path = OperationContext.Current.Host.Extensions.Find<VirtualPathExtension>();
                }
                catch (Exception) { }

                if (ctx != null)
                {
                    result = WebConfigurationManager.OpenWebConfiguration(ctx.Request.ApplicationPath);
                }
                else if (null != path)
                {
                    result = WebConfigurationManager.OpenWebConfiguration(path.VirtualPath);
                }
                else
                    result = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return result;           
            }            
        } 
    }
}

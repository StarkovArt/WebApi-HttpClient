using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Task.Domain.Concrete;

namespace Task.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<EFDbContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

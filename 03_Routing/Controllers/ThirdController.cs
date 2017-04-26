using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03_Routing.Controllers
{
    public class ThirdController : ApiController
    {
        public string GetStrng()
        {
            return "Из ThirdController этот string";
        }
    }
}

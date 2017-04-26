using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03_Routing.Controllers
{
    public class SecondController : ApiController
    {
        [HttpGet]
        public string SecondString()
        {
            return "Из SecondController этот string";
        }
    }
}

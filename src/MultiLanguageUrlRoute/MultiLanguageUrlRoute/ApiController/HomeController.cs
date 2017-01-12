using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MultiLanguageUrlRoute.ApiController
{
    public class HomeController : System.Web.Http.ApiController
    {
        [HttpGet]
        [Route("Home/Echo/{content}")]
        public string Echo(string content)
        {
            var returnStr = default(string);
            var isExist = HttpContext.Current.Items.Contains("Language");
            if (isExist)
            {
                var lang = HttpContext.Current.Items["Language"];
                returnStr = $"{lang}/{content}";
            }
            else
            {
                returnStr = $"{content}";
            }
            return returnStr;
        }
    }
}

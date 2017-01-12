using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MultiLanguageUrlRoute.Extensions
{
    public class UseAcceptCultureHandler : DelegatingHandler
    {
        private List<string> _languageList;
        private string _defaultLanguage = "en-us";

        public UseAcceptCultureHandler()
        {
            this._languageList = new List<string>
            {
                "en","ar","be","ca","cs","da","de","el","es","et","fi","fr",
                "hr","hu","is","it","iw","ja","ko","It","Iv","mk","nl","no",
                "pl","pt","ro","ru","sh","sk","sl","sq","sr","sv","th","tr",
                "uk","zh",
            };
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var lang = default(string);
            var tmp = request.RequestUri.Segments[1].Replace("/", "");
            if (tmp.Contains("-") && this._languageList.Contains(tmp.Split('-').First()))
            {
                lang = tmp.Split('-').First();
                //request.Headers.Add("Accept-Language", lang ?? _defaultLanguage);
                HttpContext.Current.Items.Add("Language", lang);
            }
            else
            {
                HttpContext.Current.Items.Add("Language", "en");
            }

            return base.SendAsync(request, cancellationToken).ContinueWith((task) =>
            {
                var response = task.Result;
                //response.Headers.Add("Accept-Language", lang ?? _defaultLanguage);
                return response;
            }, cancellationToken);
        }
    }
}
using System.Configuration;
using System.IO;
using System.Net;

namespace TestSearch.Helpers
{
    public class WebClientHelper
    {
        /// <summary>
        /// Get deserialized object
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>string json</returns>
        public static string GenerateClient(string url)
        {
            var request = WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var rd = new StreamReader(stream);
            return rd.ReadToEnd();           
        }

        /// <summary>
        /// Get google search api url
        /// </summary>
        /// <returns></returns>
        public static string FormGoogleSearchApiUrl(string query)
        {
            var GoogleCxValue = ConfigurationManager.AppSettings["GoogleCxValue"].ToString();
            var GoogleApiKey = ConfigurationManager.AppSettings["GoogleApiKey"].ToString();
            var GoogleEndPoint = ConfigurationManager.AppSettings["GoogleEndPoint"].ToString();
            var url = string.Format("{0}?key={1}&cx={2}&q={3}", GoogleEndPoint, GoogleApiKey, GoogleCxValue, query);
            return url;
        }
    }
}
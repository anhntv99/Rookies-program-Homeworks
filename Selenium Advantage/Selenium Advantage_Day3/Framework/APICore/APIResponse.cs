using CoreFramework.Reporter;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using RestSharp;
using System.Net;

namespace CoreFramework.APICore
{
    public class APIResponse : APIRequest
    {
        public HttpWebResponse response;
        
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }
        public HttpWebResponse HttpResponse;

        public APIResponse()
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        public APIResponse(HttpWebResponse httpResponse)
        {
            HttpResponse = httpResponse;
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                return responseBody;
            }
        }
        private string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException we)
            {
                responseStatusCode = ((HttpWebResponse)we.Response).StatusCode.ToString();
            }
            return responseStatusCode;
        }

        ///Try to use RESTSHARP

        //public RestResponse response;
        //private APIResponse GetResponseBody()
        //{
        //    responseBody = "";
        //    response.Content = responseBody;
        //    return this;
        //}

        //private APIResponse GetResponseStatusCode()
        //{
        //    var code = (int)response.StatusCode;
        //    return this;
        //}
    }
}

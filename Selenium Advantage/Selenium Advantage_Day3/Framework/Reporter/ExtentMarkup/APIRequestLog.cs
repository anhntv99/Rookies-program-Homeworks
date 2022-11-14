﻿using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class APIRequestLog : IMarkup
    {
        private APIRequest request { get; set; }
        private APIResponse response { get; set; }  
        public APIRequestLog(APIRequest request, APIResponse response)
        {
            this.request = request;
            this.response = response;
        }

        public string GetMarkup()
        {
            string log = $@"
                <p> Request url : {request.url}</p>
                <p> Request url : {response.requestBody}</p>
                <p>Response status: {response.responseStatusCode} <p>
                ";
            return log;
        }
    }
}

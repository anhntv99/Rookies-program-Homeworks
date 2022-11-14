using CoreFramework.APICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieTest.Service
{
    public class APIChallenge
    {
        public string baseUrl = "https://apichallenges.herokuapp.com";


        public string pathID04 = "/todo";

        public APIResponse ID4()
        {
            APIResponse response = new APIRequest()
                .SetUrl(baseUrl + "/todo")
                .SendRequest();
            return response;
        }

        public APIResponse ID5()
        {
            APIResponse response = new APIRequest()
                   .SetUrl(baseUrl + "/todos/934")
                   .SendRequest();
            return response;


        }
        public APIResponse ID6()
        {
            APIResponse response = new APIRequest()
                    .SetUrl(baseUrl + "/todos/300")
                    .SendRequest();
            return response;


        }
       
    }
}


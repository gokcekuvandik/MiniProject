using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data.Utils
{
    public static class Helper
    {
        public static IRestResponse GetRestResponse(string url)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            return new RestClient(url).Execute(request);
        }
    }
}

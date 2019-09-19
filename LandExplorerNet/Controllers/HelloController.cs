using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HelloWebAPI.Controller
{
    public class HelloController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            string data = "{ \"eid\":\"fbc246877d06bb85ab35bb47f8b7f6d48b5080507162d8625a24294183c518e7\",\"username\":\"testing@wearespork.net\",\"firstName\":\"Testing\",\"lastName\":\"User\",\"marketing\":false,\"organisation\":\"\",\"organisationNumber\":\"\",\"organisationType\":\"not-for-profit\",\"organisationActivity\":\"community-development\",\"address1\":\"\",\"address2\":\"\",\"city\":\"\",\"postcode\":\"\",\"phone\":\"\"}";
            return formatJSON(data);
        }
         
        private HttpResponseMessage formatJSON(string yourJson)
        {
            if (!string.IsNullOrEmpty(yourJson))
            {
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(yourJson, System.Text.Encoding.UTF8, "application/json");
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
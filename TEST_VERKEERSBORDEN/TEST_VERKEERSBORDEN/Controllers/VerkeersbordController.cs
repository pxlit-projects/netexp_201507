using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace TEST_VERKEERSBORDEN.Controllers
{
    public class VerkeersbordController : ApiController
    {
        // GET: api/Verkeersbord
        public List<Verkeersbord> Get()
        {
            string jsonStr;
            string url = "http://datasets.antwerpen.be/v4/gis/verkeersbordpt.json";
            using (WebClient wc = new WebClient())
            {
                jsonStr = wc.DownloadString(url);
            }

            // Haal de JSON array uit de hele string
            string[] result = jsonStr.Split(new string[] { "\"data\":" }, StringSplitOptions.None);

            string JSONArray = result.Last();

            JSONArray = JSONArray.Remove(JSONArray.Length - 1);

          
            List<Verkeersbord> data = JsonConvert.DeserializeObject<List<Verkeersbord>>(JSONArray);
            return data;
        }

        // GET: api/Verkeersbord/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Verkeersbord
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Verkeersbord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Verkeersbord/5
        public void Delete(int id)
        {
        }
    }
}

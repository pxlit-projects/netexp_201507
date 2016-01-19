using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using TEST_VERKEERSBORDEN.Models;

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

            UpdateDatabase(data);

            return data;
        }

        // GET: api/Verkeersbord/5
        public Verkeersbord Get(int objectid)
        {
            Verkeersbord verkeersbord;
            using (var context = new VerkeersbordContext())
            {
                verkeersbord = context.Verkeersborden.Find(objectid);
            }
            return verkeersbord;
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

        public void UpdateDatabase(List<Verkeersbord> data)
        {
            using ( var context = new VerkeersbordContext() ) 
            {
                foreach (Verkeersbord verkeersbord in data)
                {
                    if (context.Verkeersborden.Any(o => o.objectid == verkeersbord.objectid))
                    {
                        //Found     => Update
                        var updateBord = context.Verkeersborden.FirstOrDefault(v => v.objectid == verkeersbord.objectid);
                        updateBord.objectid = verkeersbord.objectid;
                        updateBord.point_lat = verkeersbord.point_lat;
                        updateBord.point_lng = verkeersbord.point_lng;
                        updateBord.xkey = verkeersbord.xkey;
                        updateBord.vrije_hoogte = verkeersbord.vrije_hoogte;
                        updateBord.ophanging = verkeersbord.ophanging;
                        updateBord.type = verkeersbord.type;
                        updateBord.vorm = verkeersbord.vorm;
                        updateBord.afmeting1 = verkeersbord.afmeting1;
                        updateBord.afmeting2 = verkeersbord.afmeting2;
                        updateBord.opschrift = verkeersbord.opschrift;
                        updateBord.fabtype = verkeersbord.fabtype;
                        updateBord.beeldvlak = verkeersbord.beeldvlak;
                        updateBord.fabdatum = verkeersbord.fabdatum;
                        updateBord.subkey = verkeersbord.subkey;
                        updateBord.x = verkeersbord.x;
                        updateBord.y = verkeersbord.y;
                        updateBord.shape = verkeersbord.shape;
                    }
                    else
                    {
                        //not Found => Insert
                        context.Verkeersborden.Add(verkeersbord);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}

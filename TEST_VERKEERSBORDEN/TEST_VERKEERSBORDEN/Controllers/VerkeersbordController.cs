using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;
using System.Web.Script.Serialization;
using TEST_VERKEERSBORDEN.Models;

namespace TEST_VERKEERSBORDEN.Controllers
{

    public class VerkeersbordController : ApiController
    {
        // GET: api/Verkeersbord
        public void Get()
        {
            /*using (var context = new VerkeersbordContext())
            {
                return context.Verkeersborden.ToList();
            }*/

            RetrieveOpenDataAndUpdateDatabase();
        }

        // GET: api/Verkeersbord/5
        public Verkeersbord GetByObjectid(int id)
        {
            Verkeersbord verkeersbord;
            using (var context = new VerkeersbordContext())
            {
                verkeersbord = context.Verkeersborden.Find(id);
            }
            return verkeersbord;
        }

        // POST: api/Verkeersbord
        [HttpPost]
        [Authorize(Users="AppUser")]
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Verkeersbord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Verkeersbord/5
        /*
        public void Delete(int id)
        {
        }*/

        public string PrepareJSONString (string untrimmedJSON)
        {
            string[] result = untrimmedJSON.Split(new string[] { "\"data\":" }, StringSplitOptions.None);
            string JSONArrayString = result.Last();
            JSONArrayString = JSONArrayString.Remove(JSONArrayString.Length - 1);
            return JSONArrayString;
        }

        public void RetrieveOpenDataAndUpdateDatabase()
        {
            string jsonStr;
            string url = "http://datasets.antwerpen.be/v4/gis/verkeersbordpt.json";
            using (WebClient wc = new WebClient())
            {
                jsonStr = wc.DownloadString(url);
            }

            // Trim JSON string so only the array is used
            string JSONArrayString = PrepareJSONString(jsonStr);

            List<Verkeersbord> data = JsonConvert.DeserializeObject<List<Verkeersbord>>(JSONArrayString);

            // Insert new items, update old ones
            using ( var context = new VerkeersbordContext() ) 
            {
                foreach (Verkeersbord verkeersbord in data)
                {
                    if (context.Verkeersborden.Any(o => o.objectid == verkeersbord.objectid))
                    {
                        //Found     => Update
                        var updateBord          = context.Verkeersborden.FirstOrDefault(v => v.objectid == verkeersbord.objectid);
                        updateBord.objectid     = verkeersbord.objectid;
                        updateBord.point_lat    = verkeersbord.point_lat;
                        updateBord.point_lng    = verkeersbord.point_lng;
                        updateBord.xkey         = verkeersbord.xkey;
                        updateBord.vrije_hoogte = verkeersbord.vrije_hoogte;
                        updateBord.ophanging    = verkeersbord.ophanging;
                        updateBord.type         = verkeersbord.type;
                        updateBord.vorm         = verkeersbord.vorm;
                        updateBord.afmeting1    = verkeersbord.afmeting1;
                        updateBord.afmeting2    = verkeersbord.afmeting2;
                        updateBord.opschrift    = verkeersbord.opschrift;
                        updateBord.fabtype      = verkeersbord.fabtype;
                        updateBord.beeldvlak    = verkeersbord.beeldvlak;
                        updateBord.fabdatum     = verkeersbord.fabdatum;
                        updateBord.subkey       = verkeersbord.subkey;
                        updateBord.x            = verkeersbord.x;
                        updateBord.y            = verkeersbord.y;
                        updateBord.shape        = verkeersbord.shape;
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

        /*public void TemporalUpdater()
        {
            int seconds_in_day = 3600 * 24;
            var timer = new System.Timers.Timer(seconds_in_day);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }*/

    }
}

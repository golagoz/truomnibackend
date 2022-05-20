using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChallengesTrueOmni.MyData
{
    public class FakeData
    {
      
        public IEnumerable<TrueOmni> GetAll()
        {
            IEnumerable<TrueOmni> lstSort = new List<TrueOmni>();

            using(StreamReader r = new StreamReader("dataomni.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<TrueOmni> lstOmni = JsonConvert.DeserializeObject<List<TrueOmni>>(json);

                lstSort = lstOmni;

                HashSet<string> vs = new HashSet<string>(lstOmni.Select(s => s.Company));
                var query = lstOmni.GroupBy(x => x.Company)
                      .Where(g => g.Count() > 1)
                      .Select(y => new { Element = y.Key, Counter = y.Count() })
                      .ToList();

                for (int i = 0; i < query.Count(); i++)
                {                   
                    foreach (var item in query)
                    {
                        int van = 0;
                        foreach (var omni in lstOmni)
                        {
                            if(omni.Company == item.Element)
                            {
                                van++;
                                omni.Company = omni.Company + " " + van.ToString(); 

                            }
                        }
                    }
                }
                return lstOmni;
            }
        }   
        



        public TrueOmni  GetByOne (long listingID)
        {
            List<TrueOmni> lst = new List<TrueOmni>();
            TrueOmni response = new TrueOmni();
            IEnumerable<TrueOmni> lstOmnu = new List<TrueOmni>();

            lstOmnu = this.GetAll();
            response = lstOmnu.Where(n => n.ListingID == listingID).FirstOrDefault();
            return response;
        }
    }
}

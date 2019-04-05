using Newtonsoft.Json;
using Octopart.Net.Schemas.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Request
{

    public class PartsMatchList
    {
        public PartsMatchList()
        {
            Queries = new List<PartsMatchQuery>();
            ExactOnly = false;
        }

        public List<PartsMatchQuery> Queries { get; set; }

        public bool ExactOnly { get; set; }

        public string ToQuerystring()
        {
            return JsonConvert.SerializeObject(Queries, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}

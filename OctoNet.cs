using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Octopart.Net.Schemas;
using Octopart.Net.Schemas.Objects;
using Octopart.Net.Schemas.Request;
using Octopart.Net.Schemas.Response;
using RestSharp;
using RestSharp.Serialization;

namespace Octopart.Net
{
    public partial class OctoNet : IDisposable
    {
        private string apiKey = "EXAMPLE_KEY";

        static readonly string octoPartBaseUrl = "http://octopart.com/api/v3";
        IRestClient client;

        public OctoNet(string apikey)
        {
            apiKey = apikey;
            client = new RestClient(octoPartBaseUrl).UseSerializer(() => new JsonNetSerializer());
        }

        public Brand GetBrand(string uid)
        {
            var response = ApiRequest<Brand>(new RestRequest("brands/{uid}", Method.GET).AddUrlSegment("uid", uid));

            return response;
        }
        public async Task<Brand> GetBrandAsync(string uid)
        {
            var response = await ApiRequestAsync<Brand>(new RestRequest("brands/{uid}", Method.GET).AddUrlSegment("uid", uid));

            return response;
        }


        private IRestRequest AddIncludeDirectivesToRequest(IRestRequest req, IncludeDirectives include)
        {
            if (include == IncludeDirectives.None)
                return req;

            if ((include & IncludeDirectives.CadModels) == IncludeDirectives.CadModels)
                req.AddQueryParameter("include[]", "cad_models");
            if ((include & IncludeDirectives.CategoryUIds) == IncludeDirectives.CategoryUIds)
                req.AddQueryParameter("include[]", "category_uids");
            if ((include & IncludeDirectives.ComplianceDocuments) == IncludeDirectives.ComplianceDocuments)
                req.AddQueryParameter("include[]", "compliance_documents");
            if ((include & IncludeDirectives.Datasheets) == IncludeDirectives.Datasheets)
                req.AddQueryParameter("include[]", "datasheets");
            if ((include & IncludeDirectives.Descriptions) == IncludeDirectives.Descriptions)
                req.AddQueryParameter("include[]", "descriptions");
            if ((include & IncludeDirectives.ExternalLinks) == IncludeDirectives.ExternalLinks)
                req.AddQueryParameter("include[]", "external_links");
            if ((include & IncludeDirectives.ImageSets) == IncludeDirectives.ImageSets)
                req.AddQueryParameter("include[]", "imagesets");
            if ((include & IncludeDirectives.ReferenceDesigns) == IncludeDirectives.ReferenceDesigns)
                req.AddQueryParameter("include[]", "reference_designs");
            if ((include & IncludeDirectives.ShortDescription) == IncludeDirectives.ShortDescription)
                req.AddQueryParameter("include[]", "short_description");
            if ((include & IncludeDirectives.Specs) == IncludeDirectives.Specs)
                req.AddQueryParameter("include[]", "specs");
            
            return req; // allows us to use this inline, otherwise it wouldn't be requried as req is a reference type.
        }


        public Part GetPart(string uid, IncludeDirectives include = IncludeDirectives.None)
        {
            var response = ApiRequest<Part>(AddIncludeDirectivesToRequest(new RestRequest("parts/{uid}", Method.GET).AddUrlSegment("uid", uid), include));

            return response;
        }
        public async Task<Part> GetPartAsync(string uid, IncludeDirectives include = IncludeDirectives.None)
        {
            var response = await ApiRequestAsync<Part>(AddIncludeDirectivesToRequest(new RestRequest("parts/{uid}", Method.GET).AddUrlSegment("uid", uid), include));

            return response;
        }
        public PartsMatchResponse MatchPart(PartsMatchList list, IncludeDirectives include = IncludeDirectives.None)
        {
            var request = AddIncludeDirectivesToRequest(new RestRequest("parts/match", Method.GET), include);
            request.AddQueryParameter("exact_only", list.ExactOnly ? "true" : "false");
            request.AddQueryParameter("queries", list.ToQuerystring());
            var response = ApiRequest<PartsMatchResponse>(request);


            return response;
        }
        public async Task<PartsMatchResponse> MatchPartAsync(PartsMatchList list, IncludeDirectives include = IncludeDirectives.None)
        {
            var request = AddIncludeDirectivesToRequest(new RestRequest("parts/match", Method.GET), include);
            request.AddQueryParameter("exact_only", list.ExactOnly ? "true" : "false");
            request.AddQueryParameter("queries", list.ToQuerystring());
            var response = await ApiRequestAsync<PartsMatchResponse>(request);

            return response;
        }

        private async Task<T> ApiRequestAsync<T>(IRestRequest request) where T : new()
        {
            request.AddParameter("apikey", apiKey);

            var response = await client.ExecuteTaskAsync<T>(request);

            if (response.IsSuccessful)
                return response.Data;

            throw new ApiException
            {
                StatusCode = (int)response.StatusCode,
                Content = response.ErrorMessage
            };
        }

        private T ApiRequest<T>(IRestRequest request) where T : new()
        {
            request.AddParameter("apikey", apiKey);
            
            var response =  client.Execute<T>(request);

            if (response.IsSuccessful)
                return response.Data;

            throw new ApiException
            {
                StatusCode = (int)response.StatusCode,
                Content = response.ErrorMessage
            };
        }

        /*
        private async Task<T> ApiRequestAsync<T>(CancellationToken cancellationToken, string url)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeJsonFromStream<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }
        */

        public void Dispose()
        {
            //client.Dispose();
        }
    }

    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }


    public class JsonNetSerializer : IRestSerializer
    {
        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj);

        public string Serialize(Parameter parameter) =>
            JsonConvert.SerializeObject(parameter.Value);

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content);

        public string[] SupportedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}

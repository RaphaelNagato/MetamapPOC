using MetamapPOC.Models;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace MetamapPOC.Services
{
    public class MetaMapService : IMetaMapService
    {
        private const string  baseURL = "www.govchecks.....";
        private const string  _clientSecret = "www.govchecks.....";
        private const string _clientId = "www.govchecks.....";

        public async Task<GovChecksResponse> Identify(GovChecksModel govChecksModel)
        {
            var token = await GetToken();

            var options = new RestClientOptions(baseURL);
            var client = new RestClient(options);
            client.AddDefaultHeader("Bearer", token);

            var request = new RestRequest("/v1/vin");
            request.AddBody(govChecksModel);

            var resp = await client.PostAsync<GovChecksResponse>(request);
            return resp;
        }

        private async Task<string> GetToken()
        {
            var options = new RestClientOptions(baseURL)
            {
                Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret)
            };
            var client = new RestClient(options);

            var request = new RestRequest("/oauth/token");

            // The cancellation token comes from the caller. You can still make a call without it.
            var token = await client.GetAsync<string>(request);
            return token;
        }
    }
}
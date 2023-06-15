using Antlr.Runtime.Tree;
using MetamapPOC.Models;
using MetamapPOC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebGrease;

namespace MetamapPOC.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IMetaMapService _metaMapService;

        public ValuesController(IMetaMapService metaMapService)
        {
            _metaMapService = metaMapService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public async Task<IHttpActionResult> GovChecks(GovChecksModel model)
        {
            //validate the model or use fluent validation

           var result = await _metaMapService.Identify(model);

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoraAPF.org.Facade.Interfaces.WebPages;
using DoraAPF.org.Models.WebPages;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoraAPF.org.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContentApiController : Controller
    {
        private readonly IWebPageService _webPageService;

        public ContentApiController(IWebPageService webPageService)
        {
            _webPageService = webPageService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // POST api/<controller>/PostWebPageContent
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostWebPageContent([FromBody]WebPageRequestModel webPageRequestModel)
        {
            var result = _webPageService.SubmitWebContent(webPageRequestModel.WebPageTypeId, webPageRequestModel.HtmlContent);

            return Json(new { success = result, message = result?"Update success.": "Update failed." });
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

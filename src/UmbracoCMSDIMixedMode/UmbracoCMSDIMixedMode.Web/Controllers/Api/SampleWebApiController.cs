using System.Web.Mvc;
using Umbraco.Web.WebApi;
using UmbracoCMSDIMixedMode.Web.Services;

namespace UmbracoCMSDIMixedMode.Web.Controllers.Api
{
    public class SampleWebApiController : UmbracoApiController
    {
        private readonly ISampleService _sampleService;

        public SampleWebApiController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }
        //http://localhost:60580/umbraco/api/SampleWebApi/Get
        [System.Web.Http.HttpGet]
        public JsonResult Get()
        {
            //unit test: http://blog.aabech.no/archive/the-basics-of-unit-testing-umbraco/
            return new JsonResult() { Data = new { items = _sampleService.GetItems() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
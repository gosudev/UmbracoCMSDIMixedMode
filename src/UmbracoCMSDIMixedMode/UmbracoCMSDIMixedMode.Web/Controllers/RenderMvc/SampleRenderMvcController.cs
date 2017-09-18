using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoCMSDIMixedMode.Web.Services;

namespace UmbracoCMSDIMixedMode.Web.Controllers.RenderMvc
{
    public class SampleRenderMvcController : RenderMvcController
    {
        private readonly ISampleService _sampleService;

        public SampleRenderMvcController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        public ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
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
            return CurrentTemplate(new ExtendedModel(model.Content) { Items = _sampleService.GetItems() });
        }
    }

    public class ExtendedModel : RenderModel
    {
        public ExtendedModel(IPublishedContent content)
            : base(content)
        {
        }

        public IList<string> Items { get; set; }
    }
}
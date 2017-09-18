using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoCMSDIMixedMode.Web.Services
{
    public class SampleService : ISampleService
    {
        public IList<string> GetItems()
        {
            return new List<string>()
            {
                "Autofac",
                "Ninject",
                "Unity"
            };
        }
    }
}
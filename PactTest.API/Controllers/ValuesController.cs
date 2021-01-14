using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PactTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration configuration;
        public ValuesController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IList<string> Get()
        {
            return new List<string>
            {
                "AAAAA",
                "BBBBB",
                "CCCCC"
            };
        }
    }
}

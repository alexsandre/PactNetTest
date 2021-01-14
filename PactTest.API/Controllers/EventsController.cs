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
    public class EventsController : ControllerBase
    {
        private IConfiguration configuration;
        public EventsController(IConfiguration config)
        {
            this.configuration = config;
        }

        [Route("{id:int}")]
        public Code.Event Get(int id)
        {
            
            return new Code.Event()
            {
                Id = 1,
                Description = "Event Description",
                Image = "Event image url",
                Start = DateTime.Now,
                End = DateTime.Now,
                RegistrationStart = DateTime.Now,
                RegistrationEnd = DateTime.Now
            };
        }
    }
}

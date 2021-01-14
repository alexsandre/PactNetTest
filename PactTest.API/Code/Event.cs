using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PactTest.API.Code
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }

    }
}

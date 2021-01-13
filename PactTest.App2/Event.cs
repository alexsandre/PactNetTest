using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.App2
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
    }
}

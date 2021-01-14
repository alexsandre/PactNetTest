using NUnit.Framework;
using PactNet.Infrastructure.Outputters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PactTest.API.Tests
{
    class NUnitOutput : IOutput
    {
        public void WriteLine(string line)
        {
            TestContext.WriteLine(line);
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ProgramCreation
{
    internal class SetupConfiguration
    {
        public static IConfiguration Setup()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(typeof(Program).Assembly.Location))
            .AddJsonFile("secrets.json", optional: false)
            .Build();
        }
    }
}

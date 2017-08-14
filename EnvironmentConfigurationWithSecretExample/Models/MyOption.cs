using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentConfigurationWithSecretExample.Models
{
    public class MyOption
    {
        public string EnvironmentName { get; set; }
        public string SecretKey { get; set; }
        public string SecretValue { get; set; }
    }
}

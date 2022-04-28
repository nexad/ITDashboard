using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.API.Entities
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FQDN { get; set; }
        public string Description { get; set; }
        public GlobalEnvironment GlobalEnvironment { get; set; }
        public List<Service> Services { get; set; }
    }
}

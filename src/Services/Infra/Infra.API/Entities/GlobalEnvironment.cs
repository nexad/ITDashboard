using System.Collections.Generic;

namespace Infra.API.Entities
{
    public class GlobalEnvironment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Server> Servers { get; set; }
    }
}
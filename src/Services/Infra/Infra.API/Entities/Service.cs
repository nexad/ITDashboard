namespace Infra.API.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServiceType ServiceType { get; set; }
        public Server Server { get; set; }
        public int Port { get; set; }
        public string Path { get; set; }
        public Solution Solution { get; set; }
    }
}
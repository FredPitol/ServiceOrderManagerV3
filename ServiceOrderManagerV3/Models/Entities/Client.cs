namespace ServiceOrderManagerV3.Models.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

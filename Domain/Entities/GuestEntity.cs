namespace Domain.Entities
{
    public class GuestEntity
    {

        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Contact { get; set; }

        public required string Email { get; set; }

        public required string Sender_uid { get; set; }
    }
}

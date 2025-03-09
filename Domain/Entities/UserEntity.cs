namespace Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Contact { get; set; }

        public required string Email { get; set; }

        public required string Uid { get; set; }

    }
}

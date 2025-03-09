namespace Domain.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }

        public required string sender_uid { get; set; }
        public DateTime added_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public required string user_message { get; set; }
        public  int response_message_id { get; set; } = 0;
        public bool viewed { get; set; } = false;
    }
}

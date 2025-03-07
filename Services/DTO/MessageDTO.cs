namespace PortfolioAPI_V2.DTO
{
    public class MessageDTO
    {

        public string sender_uid { get; set; }

        public string message { get; set; }
        public int response_message_id { get; set; } = 0;
    }
}

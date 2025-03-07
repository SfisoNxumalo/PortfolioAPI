using PortfolioAPI_V2.DTO;
using Domain.Entities;

namespace Services.Interfaces.Services
{
    public interface IMessageServices
    {
        public Task<MessageEntity> CreateMessage(MessageDTO message);

        public List<MessageEntity> GetAllMessages();

        public List<MessageEntity> GetAllUserMessages(string userId);

        public MessageEntity GetMessageById(int id);

        public void DeleteMessageById(int id);
    }
}

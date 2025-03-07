using Domain.Entities;

namespace Integrations.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        public List<MessageEntity> GetAll();

        public MessageEntity GetById(int id);

        public Task<MessageEntity> CreateMessage(MessageEntity message);

        public void DeleteById(int id);

        public List<MessageEntity> GetAllMessagesBySenderUid(string userId);


        //public bool UpdateById(Message message);
    }
}


using Infrastructure.Data;
using Integrations.Interfaces.Repositories;
using Domain.Entities;
using Integrations.CustomExceptions;

namespace Integrations.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseContext _context;
        public MessageRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<MessageEntity> CreateMessage(MessageEntity message)
        {
            try
            {
                _context.Message.Add(message);
                var returnMessage = await _context.SaveChangesAsync();

                return message;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to add a new user");
            }  
        }

        public List<MessageEntity> GetAll()
        {

            var messages = _context.Message.ToList();
           return messages;
        }

        public MessageEntity GetById(int id)
        {
            try
            {
                return Find(id);
            }
            catch
            {
                throw new DatabaseException("Failed to retrieve the user message");
            }
        }

        public async void DeleteById(int id)
        {
            try
            {
                var message = Find(id);

                if (message == null)
                {
                    throw new DatabaseException("The particular message does not exist.");
                }

                _context.Message.Remove(message);

                 _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
                //throw new Exception();

            }
        }

        public MessageEntity Find(int id)
        {
            return _context.Message.Find(id);
        }

        public List<MessageEntity> GetAllMessagesBySenderUid(string userId)
        {
            try
            {
                return _context.Message.Where(message => message.sender_uid == userId).ToList();
            }
            catch(Exception ex)
            {
                throw new DatabaseException("The particular message does not exist.");
            }
        }
    }
}

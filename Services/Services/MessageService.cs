
using System.Xml;
using Integrations.Interfaces.Repositories;
using PortfolioAPI_V2.DTO;
using Services.Interfaces.Services;
using Services.ServiceExceptions;
using Domain.Entities;

namespace Services.Services
{
    public class MessageService : IMessageServices
    {
        private readonly IMessageRepository _messageRepo;
        public MessageService(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }


        public async Task<MessageEntity> CreateMessage(MessageDTO message)
        {
            if (string.IsNullOrEmpty(message.sender_uid))
            {
                message.sender_uid = Convert.ToString(Guid.NewGuid());
            }

            if (string.IsNullOrEmpty(message.message))
            {
                throw new ServiceException("Please enter a valid message");
            }

            var newMessage = new MessageEntity
            {
                sender_uid = message.sender_uid,
                user_message = message.message
            };
  
            return await _messageRepo.CreateMessage(newMessage);
        }

        public List<MessageEntity> GetAllMessages()
        {
            return _messageRepo.GetAll(); 
        }

        public MessageEntity GetMessageById(int id)
        {

            if (id == null)
            {
                throw new ServiceException("Please enter a valid Id");
            }

            var message = _messageRepo.GetById(id);

            if(message == null)
            {
                throw new ServiceException("Message Not found");
            }

            return message;
        }

        public void DeleteMessageById(int id)
        {
            if (id == null)
            {
                throw new Exception("Not Id passed");
            }
            
            _messageRepo.DeleteById(id);

        }

        public List<MessageEntity> GetAllUserMessages(String userID)
        {
            if(userID == null)
            {
                throw new ServiceException("Missing user id");
            } 

            return _messageRepo.GetAllMessagesBySenderUid(userID);
        }
    }
}

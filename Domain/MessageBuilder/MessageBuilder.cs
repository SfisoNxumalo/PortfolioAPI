using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities;

namespace Domain.MessageBuilder
{
     class MessageBuilder
    {

        private readonly MessageEntity _message;

        public MessageBuilder()
        {
            _message = new MessageEntity();
        }

        public MessageBuilder SetId(int id)
        {
            _message.Id = id;
            return this;
        }

        public MessageBuilder SetSenderUid(string senderUid)
        {
            _message.sender_uid = senderUid;
            return this;
        }

        public MessageBuilder SetAddedAt(DateTime addedAt)
        {
            _message.added_at = addedAt;
            return this;
        }

        public MessageBuilder SetUpdatedAt(DateTime updatedAt)
        {
            _message.updated_at = updatedAt;
            return this;
        }

        public MessageBuilder SetUserMessage(string userMessage)
        {
            _message.user_message = userMessage;
            return this;
        }

        public MessageBuilder SetResponseMessageId(int responseMessageId)
        {
            _message.response_message_id = responseMessageId;
            return this;
        }

        public MessageBuilder SetViewed(bool viewed)
        {
            _message.viewed = viewed;
            return this;
        }

        public MessageEntity Build()
        {
            return _message;
        }
    }
}

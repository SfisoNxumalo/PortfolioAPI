using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortfolioAPI_V2.Controllers;
using PortfolioAPI_V2.DTO;
using Services.Interfaces.Services;

namespace PortfolioAPI.Tests.UnitTests
{
    public class Tests
    {
        private Mock<IMessageServices> _mockMessageService;
        private MessageController _messageController;

        [SetUp]
        public void Setup()
        {
            _mockMessageService = new Mock<IMessageServices>();
            _messageController = new MessageController(_mockMessageService.Object);
        }

        [TestCase(1)]
        [TestCase()]
        [TestCase(3)]
        public void GetMessageById_ReturnsOkResponse(int Id) //Naming
        {
            //A A A

            //Assign
            var newMessage = new MessageEntity
            {
                Id = 1,
                sender_uid = "123456789",
                added_at = DateTime.Now,
                updated_at = DateTime.Now,
                user_message = "Hello, This is a test message",
                response_message_id = 0,
                viewed = false
            };

            _mockMessageService.Setup(s => s.GetMessageById(Id)).Returns(newMessage);

            // Act
            var result = _messageController.GetMessage(Id);

            // Assert: Verify the result is OkObjectResult and status code is 200
            var okResult = result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(newMessage));
        }


        [Test]
        public async Task SendMessage_ReturnsNewMessage()
        {
            //A A A

            //Assign
            var message = new MessageDTO
            {
                //Id = 0,
                sender_uid = "5555555555bb",
                message = "Hello",
            };

            var newMessage = new MessageEntity
            {
                Id = 1,
                sender_uid = "5555555555bb",
                added_at = DateTime.Now,
                updated_at = DateTime.Now,
                user_message = "Hello",
                response_message_id = 0,
                viewed = false
            };

            _mockMessageService.Setup(s => s.CreateMessage(It.IsAny<MessageDTO>()))
                .ReturnsAsync(newMessage);

            // Act
            var result = await _messageController.SendMessage(message);


            // Assert: Verify the result is OkObjectResult and status code is 200
            var okResult = result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(newMessage));
        }

        [Test]
        public void GetMessage_ReturnsOkResponse()
        {
            //A A A

            //Assign
            var ListOfMessages = new List<MessageEntity> {
                new MessageEntity
                {
                    Id = 1,
                    sender_uid = "12345678",
                    added_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    user_message = "Hello",
                    response_message_id = 0,
                    viewed = false
                },
                new MessageEntity
                {
                    Id = 2,
                    sender_uid = "123456789",
                    added_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    user_message = "Hello",
                    response_message_id = 0,
                    viewed = false
                }
            };

            _mockMessageService.Setup(s => s.GetAllMessages()).Returns(ListOfMessages);

            // Act
            var result = _messageController.GetMessage();

            // Assert: Verify the result is OkObjectResult and status code is 200
            var okResult = result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(ListOfMessages));
        }

        
        [TestCase(1)]
        public void DeleteMessageById_ReturnsOkResponse(int Id)
        {
            //A A A

            //Assign
            var newMessage = new MessageEntity
            {
                Id = 1,
                sender_uid = "5555555555bb",
                added_at = DateTime.Now,
                updated_at = DateTime.Now,
                user_message = "Hello",
                response_message_id = 0,
                viewed = false
            };

            _mockMessageService.Setup(s => s.DeleteMessageById(Id));

            // Act
            var result = _messageController.DeleteMessage(Id);

            // Assert: Verify the result is OkObjectResult and status code is 200
            var okResult = result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

    }
}
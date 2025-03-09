using Integrations.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI_V2.DTO;
using Services.Interfaces.Services;
using Services.ServiceExceptions;


namespace PortfolioAPI_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {

        private readonly IMessageServices _messageService;

        private readonly string ErrorMessage = "We are currently experiencing an error, but do not worry the team is working on fixing the issue.";

        public MessageController(IMessageServices messageService) {
            _messageService = messageService;
        }

        [AllowAnonymous]
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDTO message)
        {
            try
            {
                var CreatedMessage = await _messageService.CreateMessage(message);

                return Ok(CreatedMessage);
            }
            catch (DatabaseException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (ServiceException e)
            {
                return StatusCode(204, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorMessage);
            }
        }

        [HttpGet("GetMessages")]
        public IActionResult GetMessages()
        {
            try
            {
                var messages = _messageService.GetAllMessages();

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorMessage);
            }
        }

        [HttpGet("GetMessage/{messageId}")]
        public IActionResult GetMessage(int messageId)
        {
            try
            {
                var messages = _messageService.GetMessageById(messageId);

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorMessage);
            }
        }

        [HttpDelete("DeleteMessage/{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            try
            {
                _messageService.DeleteMessageById(messageId);

                return Ok("Message Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorMessage);
            }
        }

        [HttpGet("GetMessages/{userId}")]
        public IActionResult GetUserMessages(string userId)
        {
            try
            {
                var messages = _messageService.GetAllUserMessages(userId);
                return Ok(messages);
            }
            catch (DatabaseException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (ServiceException e)
            {
                return StatusCode(204, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessage);
            }
        }


    }
}

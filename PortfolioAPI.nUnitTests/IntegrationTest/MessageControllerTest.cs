using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PortfolioAPI_V2;
using PortfolioAPI_V2.DTO;

namespace PortfolioAPI.Tests.IntegrationTest
{
    [TestFixture]
    public  class MessageControllerTest
    {

        private HttpClient _client;
        private DatabaseContext? _context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _context = new DatabaseContext(options);

            var _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IDbContextOptionsConfiguration<DatabaseContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Register the in-memory database for testing
                    services.AddDbContext<DatabaseContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDatabase")
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    });

                    _context.Database.EnsureCreated();

                });
            });

            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:44366")
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _context?.Database.EnsureDeleted();  // Delete the in-memory database after tests
            _context?.Dispose();  // Dispose of the DbContext to release resources
            _client.Dispose();  // Dispose of the HttpClient to release resources
        }

        [Test]
        public async Task CreateUser_ValidUser_ReturnsCreated()
        {
            // Arrange
            var Message = new MessageDTO
            {
                
                sender_uid = "123456789",
                message = "Hello, This is a test message",
                response_message_id = 0,
            };

            var data = new StringContent(JsonConvert.SerializeObject(Message), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Message/SendMessage", data);

            // Act
            var responseString = await response.Content.ReadAsStringAsync();
            var newMessage = JsonConvert.DeserializeObject<MessageEntity>(responseString);

            // AssertnewMessage
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            newMessage.Should().NotBeNull();
            newMessage.sender_uid.Should().Be(Message.sender_uid);
        }
    }
}

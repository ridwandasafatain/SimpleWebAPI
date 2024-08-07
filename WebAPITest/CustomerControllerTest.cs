using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebAPITest
{
    public class CustomerControllerTest : IClassFixture<WebApplicationFactory<WebApi.>>
    {
        private readonly HttpClient _httpClient;

        public CustomerControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }
    }
}

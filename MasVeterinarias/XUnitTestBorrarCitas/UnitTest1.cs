using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestBorrarCitas
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var client = new TestClientProvider().Client;

            var response = await client.GetAsync("/api/Cita");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

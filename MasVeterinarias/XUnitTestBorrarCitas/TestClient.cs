using MasVeterinarias.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XUnitTestBorrarCitas
{
   public class TestClientProvider
    {
        public HttpClient Client { get; set; }
        public TestClientProvider ()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client= server.CreateClient();


        }

    }
}

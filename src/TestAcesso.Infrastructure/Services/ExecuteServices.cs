using RestSharp;
using System;

namespace TestAcesso.Infrastructure.Services
{
    public abstract class ExecuteServices
    {
        private RestClient GetClient(string url)
        {
            var client = new RestClient(url);

            client.AddDefaultHeader("Accept", "text/plain");
            client.AddDefaultHeader("Content-Type", "application/json");

            return client;
        }

        public T Execute<T>(string url, RestRequest request)
        {
            var client = GetClient(url);
            var response = client.Execute<T>(request);

            if (!response.IsSuccessful)
            {
                var message = $"Error retrieving response: {response.Content}";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }

        public void Execute(string url, RestRequest request)
        {
            var client = GetClient(url);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                var message = $"Error retrieving response: {response.Content}";
                throw new ApplicationException(message, response.ErrorException);
            }
        }
    }
}

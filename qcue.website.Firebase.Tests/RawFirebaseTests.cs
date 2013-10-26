using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Newtonsoft.Json;
using QCue.Web.Models;

namespace QCue.Web.Firebase.Tests
{
    [TestClass]
    public class RawFirebaseTests
    {
        [TestMethod]
        public void Returns_Some_Queues()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://qcue-live.firebaseio.com");

            var response = client.GetAsync("queues.json").Result;

            response.EnsureSuccessStatusCode();

            var queues = response.Content.ReadAsAsync<Dictionary<string, Q>>().Result;

            Assert.IsTrue(queues.Count > 0);
        }

        [TestMethod]
        public void Returns_Some_Users()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://qcue-live.firebaseio.com");

            var response = client.GetAsync("users.json").Result;

            response.EnsureSuccessStatusCode();

            var users = response.Content.ReadAsAsync<Dictionary<string, User>>().Result;

            Assert.IsTrue(users.Count > 0);
            Assert.IsTrue(users.All(each => !String.IsNullOrWhiteSpace(each.Key)));
            Assert.IsTrue(users.All(each => each.Value != null));
        }

        [TestMethod]
        public void User_Is_Added_To_Queue()
        {
            var client = new HttpClient();

            string name = "hello";
            string key = Convert.ToString(Guid.NewGuid());
            string format = "https://qcue-live.firebaseio.com/queues/{0}/{1}.json";

            string uri = String.Format(format, key, name);

            var queue = new Q
            {
                ShortCode = "TEST",
                Users = new Dictionary<string, QUser>
                 {
                    {
                        Convert.ToString(Guid.NewGuid()),
                        new QUser
                        {
                            Id = "red",
                            State = "waiting"
                        }
                    }
                 }
            };

            var json = JsonConvert.SerializeObject(queue);
            var result = client.PutAsJsonAsync(uri, queue).Result;

            result.EnsureSuccessStatusCode();
        }
    }
}

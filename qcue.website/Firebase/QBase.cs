using Newtonsoft.Json;
using QCue.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace QCue.Web.Firebase
{
    public class QBase
    {
        private string _baseAddress;

        public QBase(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public Dictionary<string, Q> GetAllQueues()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_baseAddress);

            var response = client.GetAsync("queues.json").Result;

            response.EnsureSuccessStatusCode();

            var queues = response.Content.ReadAsAsync<Dictionary<string, Q>>().Result;

            return queues;
        }

        public Q GetQueueByShortCode(string shortCode)
        {
            var queues = this.GetAllQueues();

            var keyValue = queues.FirstOrDefault(each => each.Value.shortCode.Equals(
                shortCode, StringComparison.InvariantCultureIgnoreCase));

            if (keyValue.Value == null)
            {
                return null;
            }

            return new Q
            {
                queueId = keyValue.Key,
                name = keyValue.Value.name,
                shortCode = keyValue.Value.shortCode
            };
        }

        public User GetUserByMobileNumber(string mobile)
        {
            var users = this.GetAllUsers();

            var keyValue = users.FirstOrDefault(each => each.Value.mobile.Equals(
                mobile, StringComparison.InvariantCultureIgnoreCase));

            if (keyValue.Value == null)
            {
                return null;
            }

            return new User
            {
                userId = keyValue.Key,
                fullName = keyValue.Value.fullName,
                mobile = keyValue.Value.mobile
            };
        }

        public Dictionary<string, User> GetAllUsers()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_baseAddress);

            var response = client.GetAsync("users.json").Result;

            response.EnsureSuccessStatusCode();

            var users = response.Content.ReadAsAsync<Dictionary<string, User>>().Result;

            return users;
        }

        public void AddUserToQueue(string queueId, QUser quser)
        {
            var client = new HttpClient();
            var now = DateTime.Now.ToString("s");

            client.BaseAddress = new Uri(_baseAddress);

            string format = "queues/{0}/users/{1}.json";

            string uri = String.Format(format, queueId, now);

            var json = JsonConvert.SerializeObject(quser);
            var result = client.PutAsJsonAsync(uri, quser).Result;

            result.EnsureSuccessStatusCode();
        }

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public User AddAnonymousUser(string mobile)
        {
            var client = new HttpClient();

            var user = new User
            {
                userId = Convert.ToString(Guid.NewGuid()),
                fullName = "Anonymous",
                mobile = mobile
            };

            client.BaseAddress = new Uri(_baseAddress);

            string format = "users/{0}.json";

            string uri = String.Format(format, user.userId);

            var json = JsonConvert.SerializeObject(user);
            var result = client.PutAsJsonAsync(uri, user).Result;

            result.EnsureSuccessStatusCode();

            return user;
        }

        public void UpdateUser(User user)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_baseAddress);

            string format = "users/{0}.json";

            string uri = String.Format(format, user.userId);

            var json = JsonConvert.SerializeObject(user);
            var result = client.PutAsJsonAsync(uri, user).Result;

            result.EnsureSuccessStatusCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace SlackAPI
{
    class SlackBotClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public SlackBotClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        //Post a message using simple strings  
        public void PostMessage(string username = null, string channel = null, string img = null, Attachments attachment = null)
        {
            var payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Icon_emoji = img,
                Attachments = new List<Attachments>() { attachment }
            };

            PostMessage(payload);
        }

        //Post a message using a Payload object 
        private void PostMessage(Payload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection
                {
                    ["payload"] = payloadJson
                };

                try
                {
                    var response = client.UploadValues(_uri, "POST", data);

                    //The response text is usually "ok"  
                    string responseText = _encoding.GetString(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks  
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("icon_emoji")]
        public string Icon_emoji { get; set; }

        [JsonProperty("attachments")]
        public List<Attachments> Attachments { get; set; }
    }

    public class Attachments
    {
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("footer")]
        public string Footer { get; set; }
    }
}

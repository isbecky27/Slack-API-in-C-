using System;
using System.Collections.Generic;

namespace SlackAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var slackMessage = new SlackMessage();
            var channelList = new List<string>()
            {
                "{channel_name}",
                "@{user_id}"
            };

            foreach (var channel in channelList)
            {
                slackMessage.TestPostMessage(channel);
            }
        }
    }
}

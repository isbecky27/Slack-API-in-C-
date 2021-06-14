using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAPI
{
    class SlackMessage
    {
        public void TestPostMessage(string channel)
        {
            var urlWithAccessToken = "your url";

            var client = new SlackBotClient(urlWithAccessToken);
            var attachment = new Attachments()
            {
                Fallback = "Academy Course Start Notify : " + "{course.Name}",
                Pretext = "From now on, *" + "{course.Name}" + "* can be registered." + "\n"
                          + "Please sign up for this activity as quickly as possible.",
                Color = "#36a64f",
                Text = "*Course Name:* " + "{course.Name}" + "\n"
                       + "*Trainer:* " + "{trainersEnglishName}" + "\n"
                       + "*Registration Start Time:* " + "{course.RegistrationStartTime}" + "\n"
                       + "*Registration End Time:* " + "{course.RegistrationEndTime}" + "\n"
                       + "*Course Schedule(s):* " + "{schedules}",
                Footer = "TTS : " + "{serverDomainName}",
            };

            client.PostMessage(
                channel: channel,
                username: "Academy Course Notice",
                img: ":classical_building:",
                attachment: attachment
            );
        }
    }
}

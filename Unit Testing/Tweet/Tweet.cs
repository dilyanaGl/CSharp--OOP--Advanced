using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
    public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void Retrieve(string message)
        {
            client.WriteTweet(message);
            client.SendTweenToServer(message);
        }
    }
}


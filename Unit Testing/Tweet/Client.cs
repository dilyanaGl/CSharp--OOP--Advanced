using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
    public class MicrowaveOven : IClient
    {
        private IWriter writer;
        private ITweetRepository repo;

        public MicrowaveOven(IWriter writer, ITweetRepository repo)
        {
            this.writer = writer;
            this.repo = repo;
        }

        public void WriteTweet(string tweet)
        {
            this.writer.Print(tweet);
        }

        public void SendTweenToServer(string tweet)
        {
            this.repo.SaveTweet(tweet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tweet
{
    public class TweetRepository : ITweetRepository

    {
        private const string ServerFileName = "Tweets.txt";
        private const string MessageSeparator = "<[<Tweet>]>";
        private readonly string serverFullPath = Path.Combine(Environment.CurrentDirectory, ServerFileName);

        public void SaveTweet(string tweet)
        {
            File.AppendAllText(this.serverFullPath, $"{tweet}{MessageSeparator}");
        }
    }
}

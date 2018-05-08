using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
    public interface IClient
    {
        void WriteTweet(string tweet);
        void SendTweenToServer(string tweet);
    }
}

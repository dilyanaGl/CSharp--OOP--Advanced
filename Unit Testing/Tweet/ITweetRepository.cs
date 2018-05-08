using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
    public interface ITweetRepository
    {
        void SaveTweet(string tweet);
    }
}

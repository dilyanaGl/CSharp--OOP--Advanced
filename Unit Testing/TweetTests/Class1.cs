using Moq;
using NUnit.Framework;
using Tweet;

namespace TweetTests
{
    [TestFixture]
    public class Class1
    {
        private const string tweet = "Tweet";
        [Test]
        public void TestSendMessageToServer()
        {
            var writer = new Mock<IWriter>();
            var tweetRepo = new Mock<ITweetRepository>();
            tweetRepo.Setup(p => p.SaveTweet(It.IsAny<string>()));
            var oven = new MicrowaveOven(writer.Object, tweetRepo.Object);

            oven.SendTweenToServer(tweet);

            tweetRepo.Verify(p => p.SaveTweet(It.Is<string>(k => k == tweet)),
                "Message not saved");

        }

        [Test]
        public void TestWriteMessage()
        {
            var writer = new Mock<IWriter>();
            var tweetRepo = new Mock<ITweetRepository>();
            writer.Setup(p => p.Print(It.IsAny<string>()));
            var oven = new MicrowaveOven(writer.Object, tweetRepo.Object);

            oven.WriteTweet(tweet);
            writer.Verify(p => p.Print(It.Is<string>(k => k == tweet)),
                "Tweet does not displayed on the Cosole");
        }

        [Test]
        public void TestTweetReceiveMessage()
        {
            var client = new Mock<IClient>();
            var tweetClass = new Tweet.Tweet(client.Object);

            tweetClass.Retrieve(tweet);

            client.Setup(p => p.WriteTweet(It.IsAny<string>()));
           

            tweetClass.Retrieve(tweet);
            client.Verify(p => p.SendTweenToServer(It.Is<string>(k => k == tweet)),
                "Tweet is not sent to server");
           

        }

        [Test]
        public void TestIfPrintsOnConsole()
        {
            var client = new Mock<IClient>();

            var tweetClass = new Tweet.Tweet(client.Object);

            tweetClass.Retrieve(tweet);

            client.Setup(p => p.WriteTweet(It.IsAny<string>()));



            client.Verify(p => p.WriteTweet(It.IsAny<string>()),
                Times.Once,
                "Tweet is not diplayed on the console");

        }
    }
}



namespace Tweets.API.Configuration
{
    public  interface ITweetConfig 
    {
        string ConsumerKey { get; }

        string ConsumerSecret { get; }

        string Token { get; }

        string TokenSecret { get; }

        string TweetAPIURL { get; }

        string ScreenName { get; }

        string TweetCount { get; }
    }
}
using System.Configuration;

namespace Tweets.API.Configuration
{
    public  class TweetConfig : ITweetConfig
    {


        public string ConsumerKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ConsumerKey"];
            }
        }
        public string ConsumerSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ConsumerSecret"];
            }
        }

        public string Token
        {
            get
            {
                return ConfigurationManager.AppSettings["Token"];
            }
        }

        public string TokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["TokenSecret"];
            }
        }

        public string TweetAPIURL
        {
            get
            {
                return ConfigurationManager.AppSettings["TweetSearchAPIUrl"];
            }
        }

        public string ScreenName
        {
            get
            {
                return ConfigurationManager.AppSettings["screen_name"];
            }
        }

        public string TweetCount
        {
            get
            {
                return ConfigurationManager.AppSettings["count"];
            }
        }
    }
}
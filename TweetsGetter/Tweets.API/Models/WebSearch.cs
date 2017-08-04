using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweets.API.Models
{
    public class Url
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public List<int> indices { get; set; }
    }

    public class Medium
    {
        public object id { get; set; }
        public string id_str { get; set; }
        public List<int> indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
    }

    public class Entities
    {
        public List<object> hashtags { get; set; }
        public List<object> symbols { get; set; }
        public List<object> user_mentions { get; set; }
        public List<Url> urls { get; set; }
        public List<Medium> media { get; set; }
    }

    public class User
    {
       
        public string name { get; set; }
        public string screen_name { get; set; }
        public string profile_image_url_https { get; set; }
       
    }
    public class TweetObject
    {
        public string created_at { get; set; }
        public string text { get; set; }
        public Entities entities { get; set; }
        public string source { get; set; }
        public User user { get; set; }
        public int retweet_count { get; set; }
        
    }
}
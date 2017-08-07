
using System.Threading.Tasks;
using System.Web.Http;
using Tweets.API.Configuration;
using Tweets.API.Helpers;
using Newtonsoft.Json;
using Tweets.API.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Tweets.API.Controllers
{
    [Authorize]
    public class WebSearchesController : ApiController
    {
        // GET: api/WebSearches
        ITweetConfig Config { get; set; }

        IGetTweets GetTweets { get; set; }

        public WebSearchesController(ITweetConfig config, IGetTweets getTweets)
        {
            Config = config;
            GetTweets = getTweets;
        }

     
        public async Task<JArray> Get()
        {
            // Create client and insert an OAuth message handler in the message path that 
            // inserts an OAuth authentication header in the request      
            string rawJson = string.Empty;
            rawJson = await GetTweets.HttpGetAsync();

            var d = JsonConvert.DeserializeObject<List<TweetObject>>(rawJson);
            return JArray.FromObject(d);
        }

       
    }
}

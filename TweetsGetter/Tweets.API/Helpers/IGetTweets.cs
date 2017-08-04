using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tweets.API.Helpers
{
    public interface IGetTweets
    {
         Task<string> HttpGetAsync();
    }
}
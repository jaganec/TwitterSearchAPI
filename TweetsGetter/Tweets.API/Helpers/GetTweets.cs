using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Tweets.API.Configuration;

namespace Tweets.API.Helpers
{
    public class GetTweets : IGetTweets
    {
         ITweetConfig Config { get; set; }
        public GetTweets(ITweetConfig config)
        {
            Config = config;
        }
        public async Task<string> HttpGetAsync()
        {
            try
            {
                HttpClient client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler(), Config));
                Task<Stream> result = client.GetStreamAsync(Config.TweetAPIURL+ "screen_name="+Config.ScreenName+"&amp;count="+Config.TweetCount);

                Stream vs = await result;
                StreamReader am = new StreamReader(vs);

                return await am.ReadToEndAsync();
            }
            catch (WebException ex)
            {
                string error = string.Empty;
                switch (ex.Status)
                {
                    
                    case WebExceptionStatus.NameResolutionFailure:
                            error = "Host Not Found";                     
                    break;
                    default:
                            error = ex.Message;
                        break;
                    //We Can catch other exception types as well                  
                        
                }
                return await Task.FromResult(error);
            }
            catch(Exception ex)
            {
                return await Task.FromResult("Error Reading Tweets");                
            }
        }
    }
}

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Tweets.API.Configuration;

namespace Tweets.API.Helpers
{ /// <summary>
  /// Basic DelegatingHandler that creates an OAuth authorization header based on the OAuthBase
  /// class downloaded from http://oauth.net
  /// </summary>
    public class OAuthMessageHandler : DelegatingHandler
    {
        // Obtain these values by creating a Twitter app at http://dev.twitter.com/
        private static string  _consumerKey;
        private static string _consumerSecret;
        private static string _token;
        private static string _tokenSecret;

        private OAuthBase _oAuthBase = new OAuthBase();

        ITweetConfig Config { get; set; }

        public OAuthMessageHandler(HttpMessageHandler innerHandler, ITweetConfig config)
            : base(innerHandler)
        {
            _consumerKey = config.ConsumerKey;
            _consumerSecret = config.ConsumerSecret;
            _token = config.Token;
            _tokenSecret = config.TokenSecret;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Compute OAuth header 
            string normalizedUri;
            string normalizedParameters;
            string authHeader;

            string signature = _oAuthBase.GenerateSignature(
               request.RequestUri,
               _consumerKey,
               _consumerSecret,
               _token,
                _tokenSecret,
                request.Method.Method,
                _oAuthBase.GenerateTimeStamp(),
               _oAuthBase.GenerateNonce(),
               out normalizedUri,
               out normalizedParameters,
               out authHeader);

            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
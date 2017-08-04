using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweets.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Tweets.API.Helpers;
using Tweets.API.Configuration;
using Newtonsoft.Json.Linq;

namespace Tweets.API.Controllers.Tests
{
    [TestClass()]
    public class WebSearchesControllerTests
    {
        [TestMethod(), Description("Ensure the Method is called Once")]
        public void GetTest_MethodOnce()
        {
            Mock<ITweetConfig> mockTweetConfig = new Mock<ITweetConfig>();
            Mock<IGetTweets> mockGetTweets = new Mock<IGetTweets>();
            WebSearchesController controller = new WebSearchesController(mockTweetConfig.Object, mockGetTweets.Object);
            Task<JArray> result = controller.Get();
            mockGetTweets.Verify(m => m.HttpGetAsync(), Times.Once());

        }
    }
}
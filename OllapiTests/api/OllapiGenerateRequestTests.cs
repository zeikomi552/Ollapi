using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ollapi.api;
using Ollapi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ollapi.api.Tests
{
    [TestClass()]
    public class OllapiGenerateRequestTests
    {
        [TestMethod()]
        public void OllapiGenerateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void RequestTest()
        {
            try
            {
                OllapiGenerateRequest test = new OllapiGenerateRequest("localhost", 11434, "example");
                test.Open();
                var ret = test.Request("しりとりをしましょう。リンゴ").WaitAsync(new CancellationToken());
                var tmp = JSONUtil.DeserializeFromText<OllapiGenerateResponse>(ret.Result.ToString());
                test.Close();
            }
            catch
            {
                Assert.Fail();
            }
        }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ollapi.api;
using Ollapi.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollapi.api.Tests
{
    [TestClass()]
    public class OllapiChatRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            try
            {
                OllapiChatRequest test = new OllapiChatRequest("localhost", 11434, "example");
                test.Open();

                var message = new List<OllapiMessage>
                        {
                            new OllapiMessage()
                            {
                                Role = "user",
                                Content = "しりとりをしましょう"
                            }
                        };


                for (int i = 0; i < 10; i++)
                {
                    var ret = test.Request(message).WaitAsync(new CancellationToken());
                    var tmp = JSONUtil.DeserializeFromText<OllapiChatResponse>(ret.Result.ToString());

                    if (tmp.Message != null)
                    {
                        message.Add(tmp.Message);
                        Debug.WriteLine(tmp.Message.Role.ToString() + ":" + tmp.Message.Content);
                    }
                }

                test.Close();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
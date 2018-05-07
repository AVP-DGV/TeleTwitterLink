using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TeleTwitterLink.Services.Data;

namespace TeleTwitterLink.Tests.ServiceTests.DeserializerOfJsonTests
{
    [TestClass]
    public class DeserializerOfJson_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenStringIsEmpty()
        {
            var test = new DeserializerOfJson();
            Assert.ThrowsException<ArgumentException>(() => test.DeserializeJson<string>(string.Empty));
        }

        [TestMethod]
        public void ReturnConvertedJsons()
        {
            //var test = new DeserializerOfJson();
            //string json = "{1, 2, 3}";
            //var int[] ={[JsonProperty("id_str")]};
            
            //var result = new[] { 1, 2, 3 };
            //T convertedJsons = JsonConvert.DeserializeObject<T>(json);
            //Assert.AreEqual(result, test.DeserializeJson<int[]>(json));
        }
    }
}

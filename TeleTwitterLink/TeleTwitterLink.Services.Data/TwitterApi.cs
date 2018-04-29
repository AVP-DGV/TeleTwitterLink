using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class TwitterApi : ITwitterApi
    {
        private const string Version = "1.0";
        private const string SignatureMethod = "HMAC-SHA1";
        private static readonly DateTime EpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private readonly ITwitterKeys keys;

        public TwitterApi(ITwitterKeys keys)
        {
            this.keys = keys;
        }

        public string GetData(string resourceurl)
        {
            IEnumerable<string> parameterlist;

            var index = resourceurl.IndexOf('?');
            if (index >= 0)
            {
                parameterlist = GetParametersFromUrl(resourceurl.Substring(index + 1));
                resourceurl = resourceurl.Substring(0, index);
            }
            else
            {
                parameterlist = null;
            }

            string authheader = BuildHeader(resourceurl, parameterlist);
            return TwitterWebRequest(resourceurl, authheader, parameterlist);
        }

        private IEnumerable<string> GetParametersFromUrl(string queryString)
        {
            NameValueCollection nv = HttpUtility.ParseQueryString(queryString);
            return nv
                .AllKeys
                .Select(key => string.Concat(key, "=", Uri.EscapeDataString(nv[key])))
                .ToList();
        }

        private string BuildHeader(string resourceurl, IEnumerable<string> parameterlist)
        {
            var now = DateTime.UtcNow;
            var nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(now.Ticks.ToString()));
            var epochTimespan = now - EpochDateTime;
            var epochSeconds = ((long)epochTimespan.TotalSeconds).ToString();
            string signature = GetSignature(nonce, epochSeconds, resourceurl, parameterlist);

            return string.Concat("OAuth ",
                "oauth_consumer_key=\"", Uri.EscapeDataString(keys.ConsumerKey), "\", ",
                "oauth_nonce=\"", nonce, "\", ",
                "oauth_signature=\"", Uri.EscapeDataString(signature), "\", ",
                "oauth_signature_method=\"", SignatureMethod, "\", ",
                "oauth_timestamp=\"", epochSeconds, "\", ",
                "oauth_token=\"", Uri.EscapeDataString(keys.AccessToken), "\", ",
                "oauth_version=\"", Version, "\"");
        }

        private string GetSignature(string nonce, string timestamp, string resourceurl, IEnumerable<string> parameterlist)
        {
            var baseString = GenerateBaseString(nonce, timestamp, parameterlist);
            baseString = string.Concat("GET&", Uri.EscapeDataString(resourceurl), "&", Uri.EscapeDataString(baseString));
            var signingKey = string.Concat(Uri.EscapeDataString(keys.ConsumerSecret), "&", Uri.EscapeDataString(keys.AccessSecret));
            var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(signingKey));
            return Convert.ToBase64String(hasher.ComputeHash(Encoding.ASCII.GetBytes(baseString)));
        }

        private string GenerateBaseString(string nonce, string timestamp, IEnumerable<string> parameterlist)
        {
            var parameters = new List<string>(parameterlist)
            {
                "oauth_consumer_key=" + keys.ConsumerKey,
                "oauth_nonce=" + nonce,
                "oauth_signature_method=" + SignatureMethod,
                "oauth_timestamp=" + timestamp,
                "oauth_token=" + keys.AccessToken,
                "oauth_version=" + Version
            };

            parameters.Sort();

            return string.Join('&', parameters);
        }

        private string TwitterWebRequest(string resourceurl, string authheader, IEnumerable<string> parameterlist)
        {
            ServicePointManager.Expect100Continue = false;
            var parameters = string.Join('&', parameterlist);
            var request = (HttpWebRequest)WebRequest.Create(string.Concat(resourceurl, "?", parameters));
            request.Headers.Add("Authorization", authheader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
